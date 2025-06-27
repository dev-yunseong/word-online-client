using TMPro;
using UnityEngine;

namespace Script.GameScene
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cardNameText;

        public string CardName => cardNameText.text;

        public void Init(string name)
        {
            cardNameText.text = name;
        }

        
        public void OnCardClicked()
        {
            FindObjectOfType<CardInputSender>().TryUseCard(this);
        }
    }
}