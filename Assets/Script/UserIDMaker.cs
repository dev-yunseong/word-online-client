using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UserIDMaker
{
    public static string GetUserID()
    {
        StringBuilder sb = new StringBuilder();
        string userID;
        userID = sb.Append("User").Append(Random.Range(1000, 10000)).ToString();
        return userID;
    }
}
