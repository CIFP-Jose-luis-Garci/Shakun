using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShonuMoveAgua : MonoBehaviour
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

    public float AlturaSalto = 0f;

    public float Dash = 10f;
    float DashTime = 0.5f;

    //AL2Attack
    public GameObject AL2;
    public float AL2AttackTime = 5f;
    

    //NR2Attaack
    public GameObject AR2;
    public float AR2AttackTime = 0.1f;
    bool AR2Switch = false;



    

    [SerializeField] GameObject GotaPrefab;
    

   

    public static float Mana;


    Animator animator;

    CharacterController cc;

    float speed = 10;

    Vector3 dir;

    public static Vector2 MovePos;


    

    bool IsOnMenu;

    bool IsAttackingA;

    float ManaA;


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
        inputcontrol.Ataques.L2.performed += _ => AttackAL2();
        inputcontrol.Ataques.L2.canceled += _ => StopAL2();

        //atacandoR2
        inputcontrol.Ataques.R2.started += _ => AttackAR2();
        //inputcontrol.Ataques.R2.canceled += ctx => { AR2Switch = false; };

        

        //Saltando/Aceptar
        inputcontrol.Moverse.Saltar.performed += ctx => { saltando = true; };
        inputcontrol.Moverse.Saltar.canceled += ctx => { saltando = false; };

        //Dash/rodar
        //inputcontrol.Moverse.Roll.performed += _ => Dash();

    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

        //Cursor.lockState = CursorLockMode.Locked;

        // Cursor.visible = true;




        
    }

    // Update is called once per frame
    void Update()
    {
        ManaA = ShonuManage.MainMana;

        

        bool IsAttackingA = ShonuManage.IsAttacking;

        IsOnMenu = ScriptsMenu.PauseSwitch;

        if (ShonuManage.Alive && IsOnMenu == false)
        {
            Movimiento();
            Saltar();
            
            
            //AttackNL1();

            

        }
        else if (ShonuManage.Alive == false)
        {
            animator.SetBool("DeathShonu", true);
        }



        Gravity();


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

        if (MovePos.y > 0 && IsAttackingA == false)
        {
            transform.rotation = Quaternion.Euler(0f, SmoothAngle, 0f);
        }


        Vector3 Movement = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

        if (Dirección.magnitude >= 0.1 && IsAttackingA == false)
        {


            controller.Move(Movement.normalized * speed * Time.deltaTime);

            //rb.AddForce(Movement.normalized * speed * Time.deltaTime);


        }



        if (corriendo && MovePos.y > 0)
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


            velocity.y = 20;

            controller.Move(velocity * Time.deltaTime * AlturaSalto);



            AvaliableJump--;
        }
    }


    //ATAQUES

    void AttackAL2()
    {
        if (IsAttackingA == false && ShonuManage.MainMana >= 5)
        {
           
            IsAttackingA = true;

            animator.SetBool("IsAttackingAL2", true);

            Invoke("WaterRay", 2);

           
        }
    }
    
    void WaterRay()
    {
        AL2.gameObject.SetActive(true);

        StartCoroutine("AL2Drain");
    }
    
    
    void StopAL2()
    {
        AL2.gameObject.SetActive(false);

        IsAttackingA = false;

        animator.SetBool("IsAttackingAL2", false);

        StopCoroutine("AL2Drain");
    }

    
    IEnumerator AL2Drain()
    {
        while (true)
        {
            ShonuManage.MainMana -= 5;

            yield return new WaitForSeconds(0.5f);
        }
       
    }
    
    
    
    void AttackAR2()
    {
        if(ShonuManage.MainMana>= 40 && IsAttackingA == false) 
        {
            ShonuManage.MainMana -= 40;


            AR2.gameObject.SetActive(true);

            IsAttackingA = true;

            Invoke("StopAR2", 4);
        }

    }

    void StopAR2()
    {
        AR2.gameObject.SetActive(false);

        IsAttackingA = false;

        animator.SetBool("IsAttackingAL2", false);
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
        while (speed <= 30)
        {

            speed += 0.06f;

            yield return new WaitForSeconds(1f);
        }
    }

   

    void AddMana(int ManaValue)
    {
        Mana += ManaValue;
    }


   

    /*void Dash()
    {
        StartCoroutine("DashCoroutine")
    }

    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while(Time.time < startTime + DashTime)
        {
            controller.Move(transform.forward * Dash * Time.deltaTime);

            yield return null;

        }

        
    }
    */


}
