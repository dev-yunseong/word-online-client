using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TestStompConnector : MonoBehaviour
{
    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ConnectStomp(string userId);
    #endif
    
    void Start()
    {
    #if UNITY_WEBGL && !UNITY_EDITOR
        ConnectStomp("123"); // 예시 userId
    #endif
    }

}
