using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyUserNameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI userNameText;

    public void SetUserName(string userName)
    {
        Debug.Log($"Name : {userName}");
        this.userNameText.SetText($"Name : {userName} ");
        Debug.Log("Set UserName");
    }
}
