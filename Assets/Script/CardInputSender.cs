using System.Collections.Generic;
using Script.Data;
using Script.GameScene;
using UnityEngine;

public class CardInputSender : MonoBehaviour
{
    public static Dictionary<int,List<CardUI>> inputRequestDict = new Dictionary<int, List<CardUI>>();
    private List<string> _currentCardNameList = new List<string>();
    private List<CardUI> _currentCardList = new List<CardUI>();
    
    public bool CanSelectField => _currentCardList.Count > 0;
    
    public void TryUseCard(CardUI cardObj)
    {
        AddCardList(cardObj);
    }

    public void SendInput(Vector2 pos) //whenFieldSelect
    {
        var input = new CardUseInput(new List<string>(_currentCardNameList), pos);
        string json = JsonUtility.ToJson(input);
        
        string destination = $"/app/game/input/{SceneContext.MatchInfo.sessionId}/{SceneContext.UserID}";
        StompConnector.Instance.SendMessageToServer(destination, json);
        
        inputRequestDict.Add(input.id, _currentCardList) ;
        inputRequestDict.Add(input.id, new List<CardUI>(_currentCardList)) ;
        _currentCardNameList.Clear();
        _currentCardList.Clear();
    }
    
    
    public void AddCardList(CardUI card)
    {
        _currentCardNameList.Add(card.CardName);
        _currentCardList.Add(card);
    }
    
}