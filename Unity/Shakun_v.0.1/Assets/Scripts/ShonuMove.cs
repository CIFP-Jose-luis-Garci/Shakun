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

    public float AlturaSalto = 0f;

    public float Dash = 10f;
    float DashTime = 0.5f;

    //L2 variables
    public GameObject NL2;
    public float NL2AttackTime = 1f;
    bool L2Switch = false;

    //NR2Attaack
    public GameObject NR2;
    public float NR2AttackTime = 0.1f;
    float DashActive = 0;
    bool R2Switch = false;

    //NL1Attack
    public GameObject NL1;
    public float NL1AttackTime = 4;
    public GameObject NL1Strong;
    bool L1Switch = false;


    



    float ManaN;


    Animator animator;

    CharacterController cc;

    float speed = 10;

    Vector3 dir;

    Vector2 MovePos;

    bool IsAttackingN;

    

    bool IsOnMenu;


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
        inputcontrol.Ataques.L2.started += ctx => { L2Switch = true; };
        inputcontrol.Ataques.L2.canceled += ctx => { L2Switch = false; };

        //atacandoR2
        inputcontrol.Ataques.R2.started += ctx => { R2Switch = true; };
        inputcontrol.Ataques.R2.canceled += ctx => { R2Switch = false; };

        //atacandoL1
        inputcontrol.Ataques.L1.started += ctx => { L1Switch = true; };
        inputcontrol.Ataques.L1.canceled += ctx => { L1Switch = false; };

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
        ManaN = ShonuManage.MainMana;
        
        

        bool IsAttackingN = ShonuManage.IsAttacking;

        IsOnMenu = ScriptsMenu.PauseSwitch;

        if (ShonuManage.Alive && IsOnMenu == false)
        {
            Movimiento();
            Saltar();
            AttackNL2();
            AttackR2();
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

        if (MovePos.y > 0 && IsAttackingN == false)
        {
            transform.rotation = Quaternion.Euler(0f, SmoothAngle, 0f);
        }


        Vector3 Movement = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

        if (Dirección.magnitude >= 0.1 && IsAttackingN == false)
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


    void AttackNL2()
    {
        if (L2Switch == true && IsAttackingN == false && ShonuManage.MainMana >= 20)
        {
            ShonuManage.MainMana -= 20;

            IsAttackingN = true;

            animator.SetBool("IsAttackingL2", true);

            NL2.gameObject.SetActive(true);

            Invoke("StopNL2", NL2AttackTime);



        }
    }
    void StopNL2()
    {
        NL2.gameObject.SetActive(false);

        IsAttackingN = false;

        animator.SetBool("IsAttackingL2", false);
    }

    void AttackR2()
    {
        if (R2Switch == true && IsAttackingN == false && ShonuManage.MainMana >= 40)
        {
            ShonuManage.MainMana -= 40;

            IsAttackingN = true;

            animator.SetBool("IsAttackingR2", true);

            Invoke("AttackR2Cast", 2.5f);

        }
    }

    void AttackR2Cast()
    {

        NR2.gameObject.SetActive(true);

        //Invoke("DashNR2", 1.5f);

        Invoke("StopNR2", NR2AttackTime);


        animator.SetBool("IsAttackingR2", false);

        Invoke("NR2DashFinish", 1.1f);


    }

    void NR2DashFinish()
    {


        NR2.gameObject.SetActive(false);

        IsAttackingN = false;


    }

    
    void StopNR2()
    {
       

        NR2.gameObject.SetActive(false);

        animator.SetBool("IsAttackingR2", false);

        IsAttackingN = false;
    }
    

    /*
    void AttackNL1()
    {
        if (L1Switch==true && IsAttacking == false && Mana >= 30)
        {
            Mana -= 30;

            IsAttacking = true;

            NL1.gameObject.SetActive(true);

            // StartCoroutine("NL1Frequency");

            //Invoke("DashNR2", 1.5f);



            Invoke("StopNL1", NL1AttackTime);

        }

    }

    void StopNL1()
    {
        NL1.gameObject.SetActive(false);

        NL1Strong.gameObject.SetActive(true);

        Invoke("StopNL1Strong", 1);

        IsAttacking = false;


    }

    void StopNL1Strong()
    {
        NL1Strong.gameObject.SetActive(false);

    }

    */

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
