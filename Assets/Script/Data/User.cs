using UnityEngine.Serialization;

namespace Script.Data
{
    [System.Serializable]
    public class User
    {
        public string nickname;
        public string id;
        public string profileImageUrl;
        public string email;
    }
}