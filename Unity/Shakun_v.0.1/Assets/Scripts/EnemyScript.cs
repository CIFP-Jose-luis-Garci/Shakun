using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    


    //GAMEOBJECT GRANDE
    GameObject EnemyComp;

    //Contador de vida
    float vida = 10;
    //switch para saber si sigue con vida
    bool Alive = true;
    
    //Boolean para saber si est� stuneado
    private bool Stunned = false;

    //valor de velocidad
    public float speed = 2;

    //Variables para el FSM
    Vector3 goal; //Hacia donde se dirigir�
   

    //Necesito saber en todo momento mi distancia al objetivo
    float distance;

    //Booleana que me permite saber si ha detectado al jugador
    bool detected;
    bool pillado = false;

    //Componente Nav Mesh Agent
    NavMeshAgent agent;

    //Destinos posibles (el empty de la ronda y el jugador)
    [SerializeField] Transform emptyGoal, Shonu;

    //RigidBody
    Rigidbody rb;

    //Componente Animator
    Animator animator;

    //Sonidos
    

    //Variables para detectar al jugador
    float visionRange = 50f; //10 metros de visi�n
    float visionConeAngle = 80f; //60� de angulo de visi�n

    GameObject Hitbox;

    BoxCollider HurtBox;


    bool IsOnMenu;

    //Si es pegao te busca aunque te pierda
    bool HasBeenHit = false;


    [SerializeField] Transform ShonuNormal,ShonuAgua;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();
        
        animator = GetComponent<Animator>();

       

        

        EnemyComp = this.transform.parent.gameObject;

        
        Hitbox = this.transform.GetChild(33).gameObject;

        HurtBox = GetComponent<BoxCollider>();

        HurtBox.isTrigger = false;
        //Iniciamos la corrutina que hace que se mueva aleatoriamiente
        StartCoroutine("Ronda");


    }

    // Update is called once per frame
    void Update()
    {


        ShonuChooser();


        IsOnMenu = ScriptsMenu.PauseSwitch;

        
        
            if (agent.speed >= 0)
            {
                animator.SetBool("WalkEnemigo", true);
            }
            else
            {
                animator.SetBool("WalkEnemigo", false);
            }



            rb.AddForce(Physics.gravity * 10);

            if (Stunned == false && Alive)
            {
                //Funci�n que permite detectar al jugador
                Detectar();


                if (detected)
                {

                    goal = Shonu.position;

                }
                else
                {
                    goal = emptyGoal.position;

                }

                distance = Vector3.Distance(transform.position, goal);



                if (distance > 2f)
                {
                    agent.speed = 5f;
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

    IEnumerator Ronda()
    {

        while (!detected)
        {

            //Obtengo valores aleatorios para un nuevo Vector3
            float RandomX = Random.Range(-5f, 5f);
            float RandomZ = Random.Range(-5f, 5f);
            //Creo un Vector3 relativo a mi posici�n
            Vector3 randomPos = new Vector3(RandomX, 0, RandomZ);
            Vector3 destPos = transform.position + randomPos;

            yield return new WaitForSeconds(Random.Range(5f, 10f));

            //Muevo el objetivo a la posici�n aleatoria
            emptyGoal.transform.position = destPos;


        }
    }

    void Detectar()
    {
        //Creamos un Vector3 con la posición del jugador, y otro entre nosotros y él
        Vector3 playerPosition = Shonu.position;
        Vector3 vectorToPlayer = playerPosition - transform.position;

        //Distancia hasta el jugador y angulo que forma nuestra vision frontal con el
        //Si es una IA, podemmos con navMeshAgent, podemos usar remainingDistance
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        float angleToPlayer = Vector3.Angle(transform.forward, vectorToPlayer);

        //creamos un raycats para comprobar si est� detras de un objeto




        //Si está en mi rango y en mi ángulo de visión
        if ((distanceToPlayer <= visionRange && angleToPlayer <= visionConeAngle) || HasBeenHit == true)
        {
            
            
            if (!pillado )
            {
                
                StopCoroutine("Ronda");
                detected = true;
                pillado = true;
                //audioSource.Play();
            }
            
            if (distanceToPlayer < 2 && ShonuManage.Alive == true)
            {
                animator.SetBool("IsAttacking", true);
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                
                Hitbox.SetActive(true);

                Invoke("FinishAttack", 1);

            }
            else
            {
                animator.SetBool("IsAttacking", false);
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            }
        
        }   
        else
        {
            if (pillado)
            {
                detected = false;
                
                StartCoroutine("Ronda");
                pillado = false;
            }


        }

        

    }


    void FinishAttack()
    {
        Hitbox.SetActive(false);
    }

    void DamageTaker(int Damage)
    {
        animator.SetBool("IsGettingHit", false);

        HasBeenHit = true;

        if (vida > 0)
        {
            vida -= Damage;
            animator.SetBool("DeathEnemigo", false);

            animator.SetBool("IsGettingHit", true);

            StartCoroutine("HurtAnim");
        }

        if (vida <= 0)
        {
            Alive = false;

            animator.SetBool("DeathEnemigo", true);

            ShopEvent.CoinCount += 1;

            //rb.gameObject.SetActive(false);

            HurtBox.isTrigger = true;
            
        }

        Shonu.SendMessage("AddMana", Damage / 2);
        
        
        print(vida);
    }

    IEnumerator HurtAnim()
    {

        yield return new WaitForSeconds(0.5f);
        
        animator.SetBool("IsGettingHit", false);

    }

    public void Stun(int StunTime)
    {

        gameObject.GetComponent<NavMeshAgent>().isStopped = true;



        print("Imstunned");
        
        Stunned = true;

        //gameObject.GetComponent<Renderer>().material.color = Color.blue;

        Invoke("Stunrelease", StunTime);
    }




   /* void Moverse()
    {
        if (Stunned == false)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }


    }
   */

    IEnumerator StunCountdown()
    {

        yield return new WaitForSeconds(1f);

    }


    void Stunrelease()
    {
        // gameObject.GetComponent<Renderer>().material.color = Color.red;

        gameObject.GetComponent<NavMeshAgent>().isStopped = false;

        EnemyComp.SendMessage("EnableNavMesh");

        Stunned = false;

        
    }

    void KnockBack(int KnockbackForce)
    {
        print("BBB");

        Stun(3);


        Vector3 RegardingPos = Shonu.transform.position - transform.position;

        RegardingPos.Normalize();

        rb.AddForce(-RegardingPos * KnockbackForce, ForceMode.Impulse);


    }

    void KnockBackY(int KnockbackForceY)
    {
        
        print("OSTOY VOLANDO");
        rb.AddForce(new Vector3(0, 0.8f * KnockbackForceY, 0), ForceMode.Impulse);
    }

    void ShonuChooser()
    {
        int ShonuNumber = ShonuManage.ShonuForm;

        
        
        if(ShonuNumber == 1)
        {
            Shonu = ShonuNormal;
        }
        
        if(ShonuNumber == 2)
        {
            Shonu = ShonuAgua;
        }
  
    }
}


