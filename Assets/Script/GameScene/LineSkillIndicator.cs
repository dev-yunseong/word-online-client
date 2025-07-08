using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSkillIndicator : MonoBehaviour
{
    private void OnEnable()
    {
        if (SceneContext.Me.Equals("RightPlayer"))
        {
            transform.position = new Vector3(17, 5, 0);
        }
        else
        {
            transform.position = new Vector3(1, 5, 0);
        }   
    }

    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;

        Vector3 direction = mouseWorld - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
