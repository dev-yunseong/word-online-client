using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.GameScene
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI cardNameText;
        [SerializeField] private Sprite activeCardImage;
        [SerializeField] private Sprite inactiveCardImage;
        private bool isActive = false;
    
        public string CardName => cardNameText.text;

        public void Init(string name)
        {
            cardNameText.text = name;
        }

        public void SetCardActive(bool isActive)
        {
            this.isActive = isActive;
            GetComponent<Image>().sprite = isActive ? activeCardImage : inactiveCardImage;
        }
        
        public void OnCardClicked()
        {
            if (isActive)
            {
                FindObjectOfType<CardInputSender>().CancelUseCard(this);
                SetCardActive(false);
            }
            else
            {
                FindObjectOfType<CardInputSender>().TryUseCard(this);   
                GetComponent<Image>().sprite = activeCardImage;
                SetCardActive(true);
            }
        }
    }
}