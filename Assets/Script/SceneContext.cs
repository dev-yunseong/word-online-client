using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static string UserID
    {
        get; private set;
    }

    private void Start()
    {
        UserID = FindObjectOfType<UserInfo>().userID;
    }
}
