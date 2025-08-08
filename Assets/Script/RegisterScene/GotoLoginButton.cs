using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLoginButton : ButtonBase
{
    protected override void OnClickButton()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
