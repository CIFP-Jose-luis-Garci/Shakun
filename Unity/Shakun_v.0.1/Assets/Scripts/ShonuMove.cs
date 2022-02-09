using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShonuMove : MonoBehaviour
{
    InputControl inputcontrol;

    bool corriendo = false;
    // bool camninado = false;
    public CharacterController controller;

    public Rigidbody rb;

    public Transform Camera;

    public float TurnSmothTime = 0.3f;
    float TurnSmothness;

    private Vector3 velocity = new Vector3(0f, Physics.gravity.y, 0f);

    public static float FallingSpeed = 0.5f;

    public static bool IsGrounded = true;

    bool saltando = false;

    float AvaliableJump;

    public float AlturaSalto = 100f;

    public float Dash = 10f;

    public GameObject NL2;

    public float NL2AttackTime = 1f;

    public static int Vida;

    public bool Alive = true;

    Animator animator;

    CharacterController cc;

    float speed = 10;

    Vector3 dir;

    Vector2 MovePos;

   
    private void Awake()
    {
        inputcontrol = new InputControl();

        //Mover
        inputcontrol.Moverse.Move.performed += ctx => MovePos = ctx.ReadValue<Vector2>();
        inputcontrol.Moverse.Move.canceled += ctx => MovePos = Vector2.zero;


        //Correr
        inputcontrol.Moverse.Run.performed += ctx => { corriendo = true; };
        inputcontrol.Moverse.Run.canceled += ctx => { corriendo = false; };

        //AtacandoL2

        //Saltando
        inputcontrol.Moverse.Saltar.performed += ctx => { saltando = true; };
        inputcontrol.Moverse.Saltar.canceled += ctx => { saltando = false; };

    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = true;

        Vida = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            Movimiento();
            Saltar();
        }
        else
        {
            animator.SetBool("DeathShonu", true);
        }



        Gravity();
       
        print(AvaliableJump);

        

        
    }

    void TookDamage(int DamageTaken)
    {
        Vida -= DamageTaken;

        print(Vida);

        if (Vida <= 0)
        {
            Alive = false;
        }
    }

    void Movimiento()
    {

        animator.SetFloat("WalkShonu", MovePos.y);

        animator.SetFloat("RunFast", speed);

        //apartado de movimiento de cámara y de personaje (wasd)

        //float horizontal = Input.GetAxisRaw("Horizontal");

        float horizontal = MovePos.x;

        float vertical = MovePos.y;

        Vector3 Dirección = new Vector3(horizontal, 0f, vertical).normalized;



        //crar vector para que el controller mueva dependiendo de  donde está la cámara.

        float angle = Mathf.Atan2(Dirección.x, Dirección.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;

        float SmoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref TurnSmothness, TurnSmothTime);

        if(MovePos.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, SmoothAngle, 0f);
        }
        

        Vector3 Movement = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

        if (Dirección.magnitude >= 0.1)
        {
            

            controller.Move(Movement.normalized * speed * Time.deltaTime);

            //rb.AddForce(Movement.normalized * speed * Time.deltaTime);


        }


        
        if(corriendo && MovePos.y >0)
        {
            if (speed <= 30)
            {
                StartCoroutine("RampantRun");
            }
            else
            {
                StopCoroutine("RampantRun");
            }
            
            animator.SetBool("RunShonu", true);

            
        }
        else
        {
            speed = 5f;
            animator.SetBool("RunShonu", false);
        }


        /*

        if (Input.GetKeyDown(KeyCode.Q))
        {


            controller.Move(Movement.normalized * Dash * Time.deltaTime);

            print("AAAA");



        }
        */
    }
    
    void Gravity()
    {

        if (controller.isGrounded == false)
        {

            velocity.y -= FallingSpeed;


            controller.Move(velocity * Time.deltaTime * FallingSpeed);


        }
        else if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;


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

        if (saltando && AvaliableJump >= 0)
        {


            velocity.y = 50;

            controller.Move(velocity * Time.deltaTime * AlturaSalto);



            AvaliableJump--;
        }
    }


    private void OnEnable()
    {
        inputcontrol.Enable();
    }

    private void OnDisable()
    {
        inputcontrol.Disable();
    }


    IEnumerator RampantRun()
    {
        while (speed <= 30) {
            
            speed += 0.06f;

            yield return new WaitForSeconds(1f);
        } 
    }

}
