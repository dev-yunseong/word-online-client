using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnqueueButton : MonoBehaviour
{
    [SerializeField] StompConnector StompConnector;

    private StompConnector GetStompConnector()
    {
        if (StompConnector == null)
        {
            StompConnector = FindObjectOfType<StompConnector>();
        }
        return StompConnector;
    }
    
    public void OnClickButton()
    {
        GetStompConnector().ConnectToServer($"wss://{SceneContext.ServerIp}:{SceneContext.ServerPort}/ws?token=" + SceneContext.JwtToken);
    }
}
