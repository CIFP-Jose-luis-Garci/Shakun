using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    float health;

    public void Update()
    {
        health = ShonuManage.Vida;

        SetHealth();
    
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
        
    
    }

    public void  SetHealth()
    {
        slider.value = health;
    }
}
