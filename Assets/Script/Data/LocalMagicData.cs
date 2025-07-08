using System.Collections.Generic;

namespace Script.Data
{
    public class MagicData
    {
        public string name;
        public int mana;
        public float range;

        public MagicData(string name, int mana, float range)
        {
            this.name = name;
            this.mana = mana;
            this.range = range;
        }
    }

    public static class LocalMagicData
    {
        public static List<MagicData> dataList = new List<MagicData>()
        {
            new MagicData("Shoot",25,1f),
            new MagicData("Summon",15,1/3f),
            new MagicData("Spawn",15,1/3f),
            new MagicData("Explode",40,1/2f),
        };

        public static MagicData GetMagicData(string name)
        {
            return dataList.Find(x => x.name == name);
        }
    }
}