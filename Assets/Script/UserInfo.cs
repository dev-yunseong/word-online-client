using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string userID;

    private void Awake()
    {
        userID = UserIDMaker.GetUserID();
    }
}
