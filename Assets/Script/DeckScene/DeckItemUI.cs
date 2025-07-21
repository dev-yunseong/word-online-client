using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardNameText;

    public void Init(string cName)
    {
        cardNameText.text = cName;
    }
}
