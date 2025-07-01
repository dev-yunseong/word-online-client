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
#endif
    
    public void OnKakaoLoginSuccess(string message)
    {
        Debug.Log("카카오 로그인 성공: " + message);
        StartCoroutine(LoadUserAndLoadLobbyScene());
    }
    
    public void LoginWithKakao()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OpenKakaoLogin(kakaoLoginUrl);
#else
        Debug.Log("카카오 로그인은 WebGL에서만 동작!");
#endif
    }

    private IEnumerator LoadUserAndLoadLobbyScene()
    {
        yield return GetUser(
                () =>
                {
                    SceneManager.LoadScene("LobbyScene");
                }
            );
        
    }
        
    public IEnumerator GetUser(Action callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/api/users/mine"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Response: " + responseText);
                
                User user = JsonUtility.FromJson<User>(responseText);
                SceneContext.User = user;
                callback();
            }
        }
    }
}
