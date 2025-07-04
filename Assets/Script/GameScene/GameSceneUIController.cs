using Script.GameScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUIController : MonoBehaviour
{
    public static GameSceneUIController Instance;
    
    [SerializeField] private TextMeshProUGUI leftUserIDText;
    [SerializeField] private TextMeshProUGUI rightUserIDText;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private Slider manaSlider;
    
    [SerializeField] private Slider leftUserHpSlider;
    [SerializeField] private Slider rightUserHpSlider;
    
    [SerializeField] private CardUI cardUIPrefab;
    [SerializeField] private GameObject lowerBar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        leftUserIDText.text = SceneContext.MatchInfo.leftUserId;
        rightUserIDText.text = SceneContext.MatchInfo.rightUserId;
#endif
    }
    
    public void UpdateUserHps(int leftUserHp, int rightUserHp)
    {
        leftUserHpSlider.value = leftUserHp;
        rightUserHpSlider.value = rightUserHp;

        leftUserIDText.text = $"{SceneContext.MatchInfo.leftUserId}\n HP: {leftUserHp}";
        rightUserIDText.text = $"{SceneContext.MatchInfo.rightUserId}\n HP: {rightUserHp}";
    }

    public void UpdateMana(int mana)
    {
        manaText.text = mana.ToString();
        manaSlider.value = mana;
    }

    public void AddCard(string cardname)
    {
        CardUI cardUI = Instantiate(cardUIPrefab, lowerBar.transform);
        cardUI.Init(cardname);
    }
}
