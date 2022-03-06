using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHit : MonoBehaviour
{
    // Start is called before the first frame update


    //public float AttackCooldown;

    //public LayerMask Enemigos;

    //public LayerMask Objetos;

    //public GameObject Enemy;
   
    public AudioSource playHit;


    void Start()
    {
        gameObject.SetActive(false);
    }


    

    private void OnTriggerEnter(Collider other)
    {
       playHit.Play();
        
        if(other.gameObject.layer == 7)
        {
            
            
            other.gameObject.SendMessage("Stun", 3f);
            other.gameObject.SendMessage("DamageTaker",2);
        }
    }


}
