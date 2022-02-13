using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR2Hit : MonoBehaviour
{
    //public GameObject Enemy;



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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.gameObject.SendMessage("KnockBack", 500);

            other.gameObject.SendMessage("KnockBackY", 400);

            other.gameObject.SendMessage("DamageTaker", 7);
        }
    }

}
