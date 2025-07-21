using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI cardCountText;

    public void Init(string cName, int count)
    {
        cardNameText.text = cName;
        cardCountText.text = $" X {count.ToString()}" ;
    }
}
