using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnqueueButton : MonoBehaviour
{
    [SerializeField] StompConnector StompConnector;

    public void OnClickButton()
    {
        StompConnector.ConnectToServer("ws://localhost:8080/ws");
    }
}
