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
    }
}