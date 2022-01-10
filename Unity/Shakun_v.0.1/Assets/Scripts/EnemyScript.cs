using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private bool Stunned = false;

    public float speed = 2;

    public GameObject Enemy;

   

    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        

        Moverse();

        
    }




     public void Stun(int StunTime)
    {
        Stunned = true;

        gameObject.GetComponent<Renderer>().material.color = Color.blue;

        Invoke("Stunrelease", StunTime);
    }


    IEnumerator Wait()
    {
        while (Stunned == false)
        {
            speed = -speed;

            

            yield return new WaitForSeconds(4f);
        }


    }

    void Moverse()
    {
       if(Stunned == false)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        
       
    }

    IEnumerator StunCountdown()
    {

        yield return new WaitForSeconds(1f);

    }


    void Stunrelease()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        Stunned = false;


    }

}
