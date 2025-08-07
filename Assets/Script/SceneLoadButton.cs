using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadButton : ButtonBase
{
    [SerializeField] string sceneName;

    protected override void OnClickButton()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is not set.");
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
}
