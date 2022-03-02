using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaR2Hit : MonoBehaviour
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
            other.gameObject.SendMessage("Stun", 2f);
            other.gameObject.SendMessage("DamageTaker", 1);
        }

    }

}
