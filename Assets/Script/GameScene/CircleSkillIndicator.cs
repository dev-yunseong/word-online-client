using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSkillIndicator : MonoBehaviour
{
    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseWorld;
    }
}
