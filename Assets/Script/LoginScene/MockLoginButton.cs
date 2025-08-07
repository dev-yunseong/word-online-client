using UnityEngine;
using UnityEngine.SceneManagement;

public class MockLoginButton : ButtonBase
{
    protected override void OnClickButton()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
