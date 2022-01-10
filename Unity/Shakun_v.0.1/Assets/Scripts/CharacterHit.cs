using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHit : MonoBehaviour
{
    // Start is called before the first frame update


    //public float AttackCooldown;

    public LayerMask Enemigos;

    public LayerMask Objetos;

    public GameObject Enemy;
    
   
    
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
        if(other.gameObject.layer == 6)
        {
            print("AA");
            
            Enemy.gameObject.SendMessage("Stun", 3f);
        }
    }


}
