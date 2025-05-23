using System.Collections.Generic;
using UnityEngine;

namespace Script.Data
{
    [System.Serializable]
    public class CardUseInput
    {
        public string type = "useMagic";
        public List<string> cards;
        public int id = IDMaker.GetCardUseInputID();
        public Vector2 position;
        
        public CardUseInput(List<string> selectedCards, Vector2 pos)
        {
            cards = selectedCards;
            position = pos;
        }
    }

}