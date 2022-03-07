using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBarScript : MonoBehaviour
{

    public Slider slider;

    float BossHealth;
    
    
    
   
    // Update is called once per frame
    void Update()
    {
        BossHealth = EnemigoGrandeScript.vida;
        SetHealth();


        if (BossHealth <= 0)
        {
            gameObject.SetActive(false);
        }


    }

    public void SetHealth()
    {
        slider.value = BossHealth;
    }
}
