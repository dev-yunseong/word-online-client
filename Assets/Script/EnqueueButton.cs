using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnqueueButton : MonoBehaviour
{
    [SerializeField] TestStompConnector testStompConnector;

    public void OnClickButton()
    {
        testStompConnector.ConnectToServer("ws://localhost:8080/ws");
    }
}
