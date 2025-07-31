using System.Collections;
using System.Collections.Generic;
using Script.GameScene;
using UnityEngine;
using UnityEngine.UI;

public class ServedObjectHpBar : MonoBehaviour
{
    private ServedObject servedObject;
    private Slider slider;
    
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    
    void Update()
    {
        if (servedObject == null)
        {
            servedObject = GetComponentInParent<ServedObject>();
            return;
        }
        
        slider.maxValue = servedObject.maxHp;
        slider.value = servedObject.hp;
        
    }
}
