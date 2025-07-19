using UnityEngine;
using UnityEngine.SceneManagement;

public class MockLoginButton : MonoBehaviour
{
    public void OnClickButton()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
