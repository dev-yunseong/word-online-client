using System;
using System.Collections;
using UnityEngine;

public class PingSender : MonoBehaviour
{
    private const float PING_INTERVAL = 10f;
    
    private StompConnector stompConnector;
    private string destination;
    string pingMessage;

    [Serializable]
    class PingDto
    {
        public string type = "ping";
    }
    
    private void Awake()
    {
        pingMessage = JsonUtility.ToJson(new PingDto());
        stompConnector = FindObjectOfType<StompConnector>();
        destination = $"/app/game/input/{SceneContext.MatchInfo.sessionId}/{SceneContext.UserID}";
    }

    private void Start()
    {
        StartCoroutine(PingCoroutine());
    }
    
    private IEnumerator PingCoroutine()
    {
        while (true)
        {
            stompConnector.SendMessageToServer(destination, pingMessage);
            yield return new WaitForSeconds(PING_INTERVAL);
        }
    }
}
