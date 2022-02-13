using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL1Hit : MonoBehaviour
{
   



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.SendMessage("Stun", 4);
            other.gameObject.SendMessage("DamageTaker", 2);
        }
    }
}