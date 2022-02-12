using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    //Contador de vida
    float vida = 20;
    //switch para saber si sigue con vida
    bool Alive = true;
    
    //Boolean para saber si está stuneado
    private bool Stunned = false;

    //valor de velocidad
    public float speed = 2;

    //Variables para el FSM
    Vector3 goal; //Hacia donde se dirigirá
   

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
    //Animator animator;

    //Sonidos
    [SerializeField] AudioClip groar1;
    AudioSource audioSource;

    //Variables para detectar al jugador
    float visionRange = 30f; //10 metros de visión
    float visionConeAngle = 60f; //60º de angulo de visión

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        Shonu = GameObject.Find("Shonu").transform;

        //Iniciamos la corrutina que hace que se mueva aleatoriamiente
        StartCoroutine("Ronda");


    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Physics.gravity * 10);
        
        if(Stunned == false)
        {
            //Función que permite detectar al jugador
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
            //Creo un Vector3 relativo a mi posición
            Vector3 randomPos = new Vector3(RandomX, 0, RandomZ);
            Vector3 destPos = transform.position + randomPos;

            yield return new WaitForSeconds(Random.Range(5f, 10f));

            //Muevo el objetivo a la posición aleatoria
            emptyGoal.transform.position = destPos;


        }
    }

    void Detectar()
    {
        //Creamos un Vector3 con la posiciÃ³n del jugador, y otro entre nosotros y Ã©l
        Vector3 playerPosition = Shonu.position;
        Vector3 vectorToPlayer = playerPosition - transform.position;

        //Distancia hasta el jugador y angulo que forma nuestra vision frontal con el
        //Si es una IA, podemmos con navMeshAgent, podemos usar remainingDistance
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        float angleToPlayer = Vector3.Angle(transform.forward, vectorToPlayer);

        //creamos un raycats para comprobar si está detras de un objeto
        



        //Si estÃ¡ en mi rango y en mi Ã¡ngulo de visiÃ³n
        if ((distanceToPlayer <= visionRange && angleToPlayer <= visionConeAngle))
        {
            
            
            if (!pillado )
            {
                
                StopCoroutine("Ronda");
                detected = true;
                pillado = true;
                //audioSource.Play();
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

    void DamageTaker(int Damage)
    {
       if(vida > 0)
        {
            vida -= Damage;
        }
        
        
        
    }



    public void Stun(int StunTime)
    {

        gameObject.GetComponent<NavMeshAgent>().enabled = false;



        print("Imstunned");
        
        Stunned = true;

        gameObject.GetComponent<Renderer>().material.color = Color.blue;

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
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        Stunned = false;

        gameObject.GetComponent<NavMeshAgent>().enabled = true;
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


}


