using Script.Data;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static string UserID
    {
        get; private set;
    }

    private static User _user;

    public static User User
    {
        get { return _user; }
        set
        {
            Debug.Log("Setting User: " + value.nickname + ", ID: " + value.userID);
            UserID = value.nickname + "_" + value.userID; 
            _user = value;
        }
    }

    public static MatchedInfoDto MatchInfo
    {
        get; set;
    }

    public static string MatchResult
    {
        get; set;
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
