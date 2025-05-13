using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSceneUIController : MonoBehaviour
{

    public static GameSceneUIController Instance;
    
    [SerializeField] private TextMeshProUGUI leftUserIDText;
    [SerializeField] private TextMeshProUGUI rightUserIDText;
    [SerializeField] private TextMeshProUGUI manaText;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        leftUserIDText.text = SceneContext.MatchInfo.leftUserId;
        rightUserIDText.text = SceneContext.MatchInfo.rightUserId;
    }

    public void UpdateMana(int mana)
    {
        manaText.text = mana.ToString();
    }
}
