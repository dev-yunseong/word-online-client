using System.Collections;
using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] LobbyUserNameUI lobbyUserNameUI;

    private void Start()
    {
        Debug.Log("LobbyUIController Start");

        StartCoroutine(LoadUserInfo());
    }
    
    private IEnumerator LoadUserInfo()
    {
        yield return UserInfoGetter.GetUserInfo();
        
        lobbyUserNameUI.SetUserName(SceneContext.User.name);
    }
}
