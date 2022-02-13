using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    public Slider slider;

    float Mana;
    

    // Update is called once per frame
    void Update()
    {
        Mana = ShonuMove.Mana;

        ManaSlider();
    }


    void ManaSlider()
    {
        slider.value = Mana;
    }


}
