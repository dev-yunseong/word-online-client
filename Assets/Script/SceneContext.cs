using Script.Data;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static long UserID
    {
        get => _user.id;
    }

    private static User _user;

    public static User User
    {
        get { return _user; }
        set
        {
            Debug.Log("Setting User: " + value.nickname + ", ID: " + value.id);
            _user = value;
        }
    }

    public static string Me
    {
        get
        {
            if (UserID == MatchInfo.leftUser.id)
                return "LeftPlayer";
            else if (UserID ==MatchInfo.rightUser.id)
                return "RightPlayer";
            return "None";
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
