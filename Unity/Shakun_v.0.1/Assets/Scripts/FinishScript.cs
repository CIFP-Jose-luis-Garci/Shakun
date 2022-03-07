using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8 && EnemigoGrandeScript.vida <= 0)
        {

        }
    }





}
