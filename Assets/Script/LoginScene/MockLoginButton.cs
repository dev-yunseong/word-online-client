using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockLoginButton : MonoBehaviour
{
    [SerializeField] private KakaoLoginHelper kakaoLoginHelper;
        
    public void OnClickButton()
    {
        kakaoLoginHelper.LoadUserAndLoadLobbyScene();
    }
}
