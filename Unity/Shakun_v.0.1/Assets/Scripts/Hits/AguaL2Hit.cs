using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaL2Hit : MonoBehaviour
{ //public GameObject Enemy;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        //Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {

            if (other.gameObject.layer == 7)
            {
                other.gameObject.SendMessage("Stun", 3f);
                other.gameObject.SendMessage("DamageTaker", 0.5);
            }

    }


}
