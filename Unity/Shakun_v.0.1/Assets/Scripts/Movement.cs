using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update


    public CharacterController controller;

    public Rigidbody rb;

    public Transform Camera;

    public float speed = 5f;

    public float TurnSmothTime = 0.3f;
    float TurnSmothness;

    private Vector3 velocity = new Vector3(0f, Physics.gravity.y, 0f);

    public static float FallingSpeed = 0.5f;

    public static bool IsGrounded = true;

    float AvaliableJump;

    public float AlturaSalto = 100f;

    public float Dash = 10f;

    public GameObject NL2;

    public float NL2AttackTime = 1f;

    public static int Vida;

    public bool Alive = true;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = true;

        Vida = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        Gravity();

        // GroundChecker();

        Saltar();

        AttackNL2();
    }

    void TookDamage(int DamageTaken)
    {
        Vida -= DamageTaken;

        print(Vida);

        if(Vida<= 0)
        {
            Alive = false;
        }
    }

    void Movimiento()
    {
        //apartado de movimiento de cámara y de personaje (wasd)

        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");   

        Vector3 Dirección = new Vector3(horizontal, 0f, vertical).normalized;

        
        
       //crar vector para que el controller mueva dependiendo de  donde está la cámara.

        float angle = Mathf.Atan2(Dirección.x, Dirección.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;

        float SmoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref TurnSmothness, TurnSmothTime);

        transform.rotation = Quaternion.Euler(0f, SmoothAngle, 0f);

        Vector3 Movement = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

        if (Dirección.magnitude >= 0.1)
        {
           

            controller.Move(Movement.normalized * speed * Time.deltaTime);

            //rb.AddForce(Movement.normalized * speed * Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.LeftShift) && speed<20)
        {
            speed += 0.4f;
        }
        else
        {   
            speed = 5f;
        }


        

        if (Input.GetKeyDown(KeyCode.Q))
        {
           
          
             controller.Move(Movement.normalized * Dash * Time.deltaTime);

              print("AAAA");

               
            
        }

    }






    void Saltar()
    {

        //Vector3 TrayecoriaSalto = new Vector3(0f, AlturaSalto, 0f);

        //minetras esté en el suelo, rellena los saltos

        if (controller.isGrounded)
        {
            AvaliableJump = 1;
        }
       
        //cuando se sapresione espacio, si quedan satos guardados, saltas, cambiando tu posicion vertical. && AvaliableJump >= 0

        if (Input.GetKeyDown(KeyCode.Space) && AvaliableJump >= 0)
        {
           

            velocity.y = 50;

            controller.Move(velocity * Time.deltaTime * FallingSpeed);

            

            AvaliableJump--;
        }
    }




    void Gravity()
    {

        if (controller.isGrounded == false)
        {

            velocity.y -= FallingSpeed;


            controller.Move(velocity * Time.deltaTime * FallingSpeed);

            
        }
        else if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;

            
        }

    }




    void AttackNL2()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            NL2.gameObject.SetActive(true);

            Invoke("StopNL2", NL2AttackTime);

            

        }
    }
    void StopNL2()
    {
        NL2.gameObject.SetActive(false);
    }



    /*
    void GroundChecker()
    {

        if ((controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            velocity.y = 0;

            IsGrounded = true;
                
            print(IsGrounded);


        }
        else
        {
            IsGrounded = false;

            print(IsGrounded);
        }
    }
    */

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    
    
    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.layer == 6)
        {
            IsGrounded = false;

        }
    }
}
