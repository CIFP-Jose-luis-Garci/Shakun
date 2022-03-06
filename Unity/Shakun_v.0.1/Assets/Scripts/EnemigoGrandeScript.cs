using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemigoGrandeScript : MonoBehaviour
{



    //GAMEOBJECT GRANDE
    GameObject EnemyComp;

    //Contador de vida
    float vida = 30;
    //switch para saber si sigue con vida
    bool Alive = true;

    //Boolean para saber si est· stuneado
    private bool Stunned = false;

    //valor de velocidad
    public float speed = 2;

    //Variables para el FSM
    Vector3 goal; //Hacia donde se dirigir·


    //Necesito saber en todo momento mi distancia al objetivo
    float distance;

    //Booleana que me permite saber si ha detectado al jugador
   

    //Componente Nav Mesh Agent
    NavMeshAgent agent;

    //Destinos posibles (el empty de la ronda y el jugador)
    [SerializeField] Transform Shonu;

    //RigidBody
    Rigidbody rb;

    //Componente Animator
    Animator animator;

    //Sonidos


    //Variables para detectar al jugador
    

    GameObject Hitbox;

    BoxCollider HurtBox;


    bool IsOnMenu;

    //Si es pegao te busca aunque te pierda
    bool HasBeenHit = false;


    [SerializeField] Transform ShonuNormal, ShonuAgua;

    [SerializeField] GameObject Attack0, Attack1, Attack2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();





        //EnemyComp = this.transform.parent.gameObject;


        //Hitbox = this.transform.GetChild(33).gameObject;

        HurtBox = GetComponent<BoxCollider>();

        HurtBox.isTrigger = false;
        //Iniciamos la corrutina que hace que se mueva aleatoriamiente



    }

    // Update is called once per frame
    void Update()
    {


        ShonuChooser();


        IsOnMenu = ScriptsMenu.PauseSwitch;



        if (agent.speed >= 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }



        rb.AddForce(Physics.gravity * 10);

        if (Stunned == false && Alive)
        {
            //FunciÛn que permite detectar al jugador
            Detectar();



            goal = Shonu.position;




            distance = Vector3.Distance(transform.position, goal);



            if (distance > 2f)
            {
                agent.speed = 7f;
            }
            else
            {
                agent.speed = 0f;
            }
            agent.SetDestination(goal);
        }
        else
        {

        }





    }



    void Detectar()
    {
        //Creamos un Vector3 con la posici√≥n del jugador, y otro entre nosotros y √©l
        Vector3 playerPosition = Shonu.position;
        Vector3 vectorToPlayer = playerPosition - transform.position;

        //Distancia hasta el jugador y angulo que forma nuestra vision frontal con el
        //Si es una IA, podemmos con navMeshAgent, podemos usar remainingDistance
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        float angleToPlayer = Vector3.Angle(transform.forward, vectorToPlayer);

        //creamos un raycats para comprobar si est· detras de un objeto


        if (distanceToPlayer < 4 && ShonuManage.Alive == true)
        {
            int AttackNumber = Random.Range(0, 3);


            animator.SetBool("IsAttacking", true);
            animator.SetInteger("AttackNumber",AttackNumber);

            
            
            
            
            if(AttackNumber == 0)
            {
                Attack0.SetActive(true);

                Invoke("Attack0End", 1);
            }

            else if(AttackNumber == 1)
            {
                Attack1.SetActive(true);

                Invoke("Attack1End", 1);
            }
            
            else if(AttackNumber == 2)
            {
                Attack2.SetActive(true);

                Invoke("Attack2End", 0.5f);
            }
            
            
            void Attack0End()
            {
                Attack0.SetActive(false);
            }

            void Attack1End()
            {
                Attack1.SetActive(false);
            }

            void Attack2End()
            {
                Attack2.SetActive(false);
            }

            gameObject.GetComponent<NavMeshAgent>().isStopped = true;

            //Hitbox.SetActive(true);

            Invoke("FinishAttack", 1);

        }
        else
        {
            animator.SetBool("IsAttacking", false);
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }

    }


    void FinishAttack()
    {
        //Hitbox.SetActive(false);
    }

    void DamageTaker(int Damage)
    {
        animator.SetBool("IsGettingHit", false);

        HasBeenHit = true;

        if (vida > 0)
        {
            vida -= Damage;

        }

        if (vida <= 0)
        {
            Alive = false;



            HurtBox.isTrigger = true;

        }



    }


    void ShonuChooser()
    {
        int ShonuNumber = ShonuManage.ShonuForm;



        if (ShonuNumber == 1)
        {
            Shonu = ShonuNormal;
        }

        if (ShonuNumber == 2)
        {
            Shonu = ShonuAgua;
        }

    }
}




