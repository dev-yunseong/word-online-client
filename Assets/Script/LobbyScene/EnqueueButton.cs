using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnqueueButton : ButtonBase
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
    
    protected override void OnClickButton()
    {
        GetStompConnector().ConnectToServer(SceneContext.CurrentServer.webSocketUrl + SceneContext.JwtToken);
    }
}
