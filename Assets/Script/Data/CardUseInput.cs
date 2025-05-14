using System.Collections.Generic;

namespace Script.Data
{
    [System.Serializable]
    public class CardUseInput
    {
        public string type = "useMagic";
        public List<string> cards;
        public int id = IDMaker.GetCardUseInputID();
        
        public CardUseInput(List<string> selectedCards)
        {
            cards = selectedCards;
        }
    }

}