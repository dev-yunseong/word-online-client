using System;
using System.Collections;
using UnityEngine;
using System.Runtime.InteropServices;
using Script.Data;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class KakaoLoginHelper: MonoBehaviour
{
    private string kakaoLoginUrl = "http://localhost:8080/api/auth/kakao";
    
    private void Awake()
    {
        gameObject.name = "KakaoLoginHelper";
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void OpenKakaoLogin(string url);
    
    [DllImport("__Internal")]
    private static extern void GetUserInfo();
#endif
    
    public void OnKakaoLoginSuccess(string message)
    {
        Debug.Log("카카오 로그인 성공: " + message);
        LoadUserAndLoadLobbyScene();
    }
    
    public void LoginWithKakao()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OpenKakaoLogin(kakaoLoginUrl);
#else
        Debug.Log("카카오 로그인은 WebGL에서만 동작!");
#endif
    }

    private void LoadUserAndLoadLobbyScene()
    {
        GetUser(
            () =>
            {
                SceneManager.LoadScene("LobbyScene");
            }
        );
    }
        
    Action userInfoCallback;
    public void GetUser(Action callback)
    {
        userInfoCallback = callback;
#if UNITY_WEBGL && !UNITY_EDITOR
        GetUserInfo();
#endif
    }
    
    public void OnKakaoUserInfoSuccess(string userInfoJson)
    {
        User user = JsonUtility.FromJson<User>(userInfoJson);
        SceneContext.User = user;
        userInfoCallback();
        userInfoCallback = null;
    }
}