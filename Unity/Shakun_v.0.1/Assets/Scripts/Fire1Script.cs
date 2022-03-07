using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1Script : MonoBehaviour
{

    public static bool Lit1 = true;

   


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            print("Agua");


            Lit1 = false;

            gameObject.SetActive(false);
        }
    }



}
