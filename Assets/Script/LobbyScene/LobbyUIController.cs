using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] LobbyUserNameUI lobbyUserNameUI;

    private void Start()
    {
        Debug.Log("LobbyUIController Start");
        lobbyUserNameUI.SetUserName(SceneContext.User.nickname);
    }
}
