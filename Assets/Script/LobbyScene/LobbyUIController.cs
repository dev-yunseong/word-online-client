using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField] LobbyUserNameUI lobbyUserNameUI;

    private void Start()
    {
        lobbyUserNameUI.SetUserID(SceneContext.UserID);
    }
}
