using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NL1StrongHit : MonoBehaviour
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
            other.gameObject.SendMessage("KnockBack", 400);
            other.gameObject.SendMessage("KnockBackY", 1000);
        }
    }
}
