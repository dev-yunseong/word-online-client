using System;
using System.Collections;
using System.Collections.Generic;
using Script.Global;
using UnityEngine;

public class EnqueueButton : AsyncButtonBase
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
        try
        {
            GetStompConnector().ConnectToServer(SceneContext.CurrentServer.webSocketUrl + SceneContext.JwtToken);
        }
        catch (Exception e)
        {
            ResetButton();
        }
    }
}
