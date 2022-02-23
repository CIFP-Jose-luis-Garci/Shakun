using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float AL2AttackTime = 1f;
    bool AL2Switch = false;

    //NR2Attaack
    public GameObject AR2;
    public float AR2AttackTime = 0.1f;
    bool AR2Switch = false;




    int VidaAgua;

    public static bool Alive = true;

    public bool IsAttacking = false;

    public static float Mana;


    Animator animator;

    CharacterController cc;

    float speed = 10;

    Vector3 dir;

    Vector2 MovePos;


    int Invuln = 5;

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
        inputcontrol.Ataques.L2.started += ctx => { AL2Switch = true; };
        inputcontrol.Ataques.L2.canceled += ctx => { AL2Switch = false; };

        //atacandoR2
        inputcontrol.Ataques.R2.started += ctx => { AR2Switch = true; };
        inputcontrol.Ataques.R2.canceled += ctx => { AR2Switch = false; };

        

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




        Mana = 100;

        StartCoroutine("ManaRegen");
    }

    // Update is called once per frame
    void Update()
    {
        VidaAgua = ShonuManage.Vida;


        IsOnMenu = ScriptsMenu.PauseSwitch;

        if (ShonuManage.Alive && IsOnMenu == false)
        {
            Movimiento();
            Saltar();
            AttackAL2();
            AttackAR2();
            //AttackNL1();

            

        }
        else if (ShonuManage.Alive == false)
        {
            animator.SetBool("DeathShonu", true);
        }



        Gravity();


    }

    void TookDamage(int DamageTaken)
    {
        if (Invuln >= 5)
        {
            VidaAgua -= DamageTaken;
            print(VidaAgua);

            Invuln = 0;

            StartCoroutine("InvulnTime");
        }




        if (VidaAgua <= 0)
        {
            ShonuManage.Alive = false;

            StartCoroutine("ShonuDeath");
        }
    }

    IEnumerator InvulnTime()
    {
        while (Invuln < 5)
        {
            Invuln += 1;

            yield return new WaitForSeconds(0.3f);
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

        if (MovePos.y > 0 && IsAttacking == false)
        {
            transform.rotation = Quaternion.Euler(0f, SmoothAngle, 0f);
        }


        Vector3 Movement = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

        if (Dirección.magnitude >= 0.1 && IsAttacking == false)
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

    }
   
    void AttackAR2()
    {

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

    IEnumerator ManaRegen()
    {
        while (true)
        {
            print("your MOM");

            Mana += 0.6f;

            yield return new WaitForSeconds(0.3f);
        }
    }

    void AddMana(int ManaValue)
    {
        Mana += ManaValue;
    }


    IEnumerator ShonuDeath()
    {
        yield return new WaitForSeconds(4);


        SceneManager.LoadScene(6);
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
