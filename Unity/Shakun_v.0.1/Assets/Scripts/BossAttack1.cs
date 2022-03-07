using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    GameObject Shonu;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        Shonu = GameObject.Find("Shonu");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {

            Shonu.SendMessage("TookDamage", 4);
        }
    }
}
