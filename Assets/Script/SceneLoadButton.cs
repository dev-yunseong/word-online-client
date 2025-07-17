using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    
    public void OnClickButton()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Scene name is not set.");
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
}
