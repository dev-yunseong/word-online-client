using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSceneUIController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI leftUserIDText;
    [SerializeField] private TextMeshProUGUI rightUserIDText;
    
    private void Start()
    {
        leftUserIDText.text = SceneContext.MatchInfo.user1;
        rightUserIDText.text = SceneContext.MatchInfo.user2;
    }
}
