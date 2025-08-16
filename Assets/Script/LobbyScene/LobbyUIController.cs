using System.Collections;
using System.Linq;
using Script.DeckScene;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] LobbyUserNameUI lobbyUserNameUI;
    [SerializeField] private TMP_Dropdown deckDropdown;
    [SerializeField] private Button arrowButton;
    private DeckResponseDto[] userDecks;

    private void Start()
    {
        Debug.Log("LobbyUIController Start");

        deckDropdown.onValueChanged.AddListener(OnDropdownChanged);
        StartCoroutine(LoadUserInfo());
    }
    
    private IEnumerator LoadUserInfo()
    {
        yield return UserInfoGetter.GetUserInfo();
        
        lobbyUserNameUI.SetUserName(SceneContext.User.name);
        yield return FetchDecks();
    }

    public IEnumerator FetchDecks()
    {
        string url = $"{SceneContext.CurrentServer.url}/api/users/mine/decks";
        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Authorization", "Bearer " + SceneContext.JwtToken);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            SystemMessageUI.Instance.ShowMessage("덱 리스트 로드 실패");
            Debug.LogError($"덱 리스트 로드 실패: {www.error}");
            yield break;
        }

        // JsonHelper 는 이전에 정의한 generic 래퍼 유틸리티
        userDecks = JsonHelper.FromJson<DeckResponseDto>(www.downloadHandler.text);
        
        PopulateDropdown();
    }

    // 2) 드랍다운 옵션 갱신
    private void PopulateDropdown()
    {
        // 옵션 이름만 뽑아서 리스트로
        var names = userDecks.Select(d => d.name).ToList();

        // 드랍다운 옵션 클리어 후 추가
        deckDropdown.ClearOptions();
        deckDropdown.AddOptions(names);

        // 현재 선택된 덱 인덱스 찾아 세팅
        int idx = userDecks
            .Select(d => d.id)
            .ToList()
            .IndexOf(DeckSceneContext.CurrentDeck.id);
        idx = Mathf.Clamp(idx, 0, names.Count - 1);

        deckDropdown.value = idx;
        deckDropdown.RefreshShownValue();
        UpdateCaption(names[idx]);
    }

    // 3) 드랍다운에서 선택 바뀌었을 때
    public void OnDropdownChanged(int newIndex)
    {
        
        var selected = userDecks[newIndex];
        DeckSceneContext.CurrentDeck = selected;     // 컨텍스트 갱신
        Debug.Log($"index: {newIndex} 선택된 덱: {selected.name} (ID: {selected.id})");
        UpdateCaption(selected.name);                // 상단 텍스트 갱신
        StartCoroutine(SelectDeckCoroutine(DeckSceneContext.CurrentDeck.id));
    }
    private IEnumerator SelectDeckCoroutine(long deckId)
    {
        string url = $"{SceneContext.CurrentServer.url}/api/users/mine/decks/{deckId}";
        using var www = UnityWebRequest.Post(url, new WWWForm());
        www.SetRequestHeader("Authorization", "Bearer " + SceneContext.JwtToken);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            SystemMessageUI.Instance.ShowMessage("덱 선택 실패");
            Debug.LogError($"덱 선택 실패: {www.responseCode} / {www.error}");
        }
        else
        {
            SystemMessageUI.Instance.ShowMessage("덱 선택 성공");
            Debug.Log("덱 선택 성공: " + www.downloadHandler.text);
        }
    }
    private void UpdateCaption(string deckName)
    {
        if (deckDropdown.captionText != null)
            deckDropdown.captionText.text = deckName;
    }
}
