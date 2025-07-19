using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class JsonHelper {
    public static T[] FromJson<T>(string json) {
        string wrapped = "{\"Items\":" + json + "}";
        var wrapper = JsonUtility.FromJson<Wrapper<T>>(wrapped);
        return wrapper.Items;
    }
    [System.Serializable]
    private class Wrapper<T> {
        public T[] Items;
    }
}

[System.Serializable]
public class CardDto {
    public long id;
    public string name;
}

[System.Serializable]
public class DeckResponseDto {
    public long id;
    public string name;
    public CardDto[] cards;
}

[System.Serializable]
public class CardPoolDto {
    public CardDto[] cards;
}

public class DeckManagementController : MonoBehaviour
{
    [Header("UI")]
    public Transform deckListContainer;      // 덱 버튼들
    public Button deckButtonPrefab;
    public Transform deckCardsContainer;     // 선택된 덱 카드
    public Transform ownedCardsContainer;    // 보유 카드
    public GameObject cardItemPrefab;        // 카드 UI 프리팹

    private List<DeckResponseDto> userDecks;
    private CardDto[] ownedCards;

    void Start() {
        StartCoroutine(LoadAll());
    }

    IEnumerator LoadAll() {
        var token = SceneContext.JwtToken; 

        // 2) 요청 생성 (GET)
        string urlCards = SceneContext.ServerUrl + "/api/users/mine/cards";
        using var wwwPool = new UnityWebRequest(urlCards, "GET");
    
        // 3) 헤더 설정
        wwwPool.SetRequestHeader("Authorization", "Bearer " + token);

        // 4) 다운로드 핸들러 할당
        wwwPool.downloadHandler = new DownloadHandlerBuffer();

        // 5) 전송
        yield return wwwPool.SendWebRequest();

        // 6) 결과 체크
        if (wwwPool.result != UnityWebRequest.Result.Success) {
            Debug.LogError(
                $"보유 카드 풀 로드 실패: {wwwPool.responseCode} / {wwwPool.error}\n{wwwPool.downloadHandler.text}"
            );
            yield break;
        }

        // 7) 파싱
        Debug.Log($"보유 카드 리스트: {wwwPool.downloadHandler.text}");
        var poolDto = JsonUtility.FromJson<CardPoolDto>(wwwPool.downloadHandler.text);
        ownedCards = poolDto.cards ?? new CardDto[0];
        

        // 2) 요청 생성 (GET)
        string urlDeck = SceneContext.ServerUrl + "/api/users/mine/decks";
        using var wwwDecks = new UnityWebRequest(urlDeck, "GET");
    
        // 3) 헤더 설정
        wwwDecks.SetRequestHeader("Authorization", "Bearer " + token);

        // 4) 다운로드 핸들러 할당
        wwwDecks.downloadHandler = new DownloadHandlerBuffer();

        // 5) 전송
        yield return wwwDecks.SendWebRequest();

        // 6) 결과 체크
        if (wwwDecks.result != UnityWebRequest.Result.Success) {
            Debug.LogError(
                $"유저 덱 리스트 로드 실패: {wwwDecks.responseCode} / {wwwDecks.error}\n{wwwDecks.downloadHandler.text}"
            );
            yield break;
        }

        // 7) 파싱
        Debug.Log($"유저 덱 리스트: {wwwDecks.downloadHandler.text}");
        var decks = JsonHelper.FromJson<DeckResponseDto>(wwwDecks.downloadHandler.text);
        PopulateDeckList();
    }

    void PopulateDeckList() {
        foreach (var deck in userDecks) {
            var btn = Instantiate(deckButtonPrefab, deckListContainer);
            btn.GetComponentInChildren<Text>().text = deck.name;
            btn.onClick.AddListener(() => OnDeckSelected(deck));
        }
    }

    void OnDeckSelected(DeckResponseDto deck) {
        // clear
        foreach (Transform t in deckCardsContainer) Destroy(t.gameObject);
        foreach (Transform t in ownedCardsContainer) Destroy(t.gameObject);

        // 덱 카드 표시
        foreach (var c in deck.cards) {
            var item = Instantiate(cardItemPrefab, deckCardsContainer);
            var ui = item.GetComponent<CardItemUI>();
            ui.Setup((int)c.id, c.name, 1); // count 정보는 cards 배열 내 동일 카드 수로 이미 분리됨
        }

        // 보유 카드 표시
        foreach (var c in ownedCards) {
            var item = Instantiate(cardItemPrefab, ownedCardsContainer);
            var ui = item.GetComponent<CardItemUI>();
            ui.Setup((int)c.id, c.name, /* 실제 보유 수 표시하려면 서버에서 count 추가 필드 필요 */ 1);
        }
    }
}
