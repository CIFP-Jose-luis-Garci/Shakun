using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBarScript : MonoBehaviour
{
    public Slider slider;

    float Bosshealth;

    public void Update()
    {
        Bosshealth = EnemigoGrandeScript.vida;

        SetHealth();
    }

    public void SetHealth()
    {
        slider.value = Bosshealth;
    }
}
