using System.Collections.Generic;
using Script.Data;
using UnityEngine;

public class CardInputSender : MonoBehaviour
{
    public static Dictionary<int,GameObject> inputRequestDict = new Dictionary<int, GameObject>();
    
    public void TryUseCard(string cardName, GameObject cardObj)
    {
        var selectedCards = new List<string> { cardName }; // 지금은 하나만 예시
        var input = new CardUseInput(selectedCards);
        string json = JsonUtility.ToJson(input);
        
        string destination = $"/app/game/input/{SceneContext.MatchInfo.sessionId}/{SceneContext.UserID}";
        StompConnector.Instance.SendMessageToServer(destination, json);
        
        inputRequestDict.Add(input.id, cardObj) ;
        
    }
    
}