using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOT : MonoBehaviour
{
    public GameObject Victim;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Shonu")
        {
            print("AY");
            StartCoroutine("Damage");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            StopCoroutine("Damage");
        }
    }

    IEnumerator Damage()
    {
        while (true)
        {
            Victim.gameObject.SendMessage("TookDamage", 10);

            yield return new WaitForSeconds(1f);
        }
        
        
    }
}
