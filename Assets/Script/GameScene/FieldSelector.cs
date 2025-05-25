using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSelector : MonoBehaviour
{
    CardInputSender cardInputSender;
    private GameObject currentAimObj;
    [SerializeField] private GameObject aimObject;

    private void Start()
    {
        cardInputSender = FindObjectOfType<CardInputSender>();
        currentAimObj = Instantiate(aimObject);
    }

    void Update()
    {
        if (cardInputSender.CanSelectField)
        {
            if(!currentAimObj.activeSelf) currentAimObj.SetActive(true);
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentAimObj.transform.position = mouseWorldPos;
            if (Input.GetMouseButtonDown(0))
            {
                cardInputSender.SendInput(mouseWorldPos);
                currentAimObj.SetActive(false);
            }
        } else {
            if (currentAimObj.activeSelf) currentAimObj.SetActive(false);
        }
        

    }
}
