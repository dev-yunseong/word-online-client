using TMPro;
using UnityEngine;

namespace Script.GameScene
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cardNameText;

        public void Init(string name)
        {
            cardNameText.text = name;
        }
        
        // 버튼에 연결해서 호출 가능
        public void OnCardClicked()
        {
            GetComponent<CardInputSender>().TryUseCard(cardNameText.text,gameObject);
        }
    }
}