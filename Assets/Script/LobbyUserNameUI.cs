using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyUserNameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI userIDText;

    public void SetUserID(string userID)
    {
        this.userIDText.text = "Name : " + userID;
    }
}
