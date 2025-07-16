using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    public void OnButtonClick()
    {
        StartCoroutine(LoginCoroutine(
            new LoginRequestDto(emailInputField.text, passwordInputField.text)
            ));
    }
    
    private IEnumerator LoginCoroutine(LoginRequestDto loginRequestDto)
    {
        string jsonData = JsonUtility.ToJson(loginRequestDto);
        
        using (UnityWebRequest webRequest = new UnityWebRequest("http://localhost:8080/api/users/login", "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + webRequest.error);
                yield break;
            }
            
            Debug.Log("Response: " + webRequest.downloadHandler.text);
            
            AuthResponseDto authResponseDto = JsonUtility.FromJson<AuthResponseDto>(webRequest.downloadHandler.text);
            
            SceneContext.JwtToken = authResponseDto.jwtToken;
        }
        
        SceneManager.LoadScene("LobbyScene");
    }
}
