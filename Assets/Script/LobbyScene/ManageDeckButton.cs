using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageDeckButton : ButtonBase
{
    protected override void OnClickButton()
    {
        SceneManager.LoadScene("ManageDeckScene");
    }
}
