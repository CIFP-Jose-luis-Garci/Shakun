using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiMove : MonoBehaviour
{

    Vector3 goal;

    float speed;

    float Distance;

    bool Detected;

    bool pillado;

    NavMeshAgent agent;

    [SerializeField] Transform emptyGoal, survivor, obstaculo;

    Animator animator;


    float visionRange = 10f; //10 metros de visión
    float visionConeAngle = 60f; //60º de angulo de visión


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        survivor = GameObject.Find("Survivor (1)").transform;

        StartCoroutine("Ronda");

        //emptyGoal.transform.position = new Vector3(Random.Range())
    }

    // Update is called once per frame
    void Update()
    {
        /* goal = GameObject.Find("Survior (1)").transform.position;

         Distance = Vector3.Distance(transform.position, goal);

        


         agent.speed = 4;*/




        Detectar();

        if (Detected)
        {



            //animator.SetBool("Atack", true);
            goal = survivor.position;
            //audioSource.Play();




        }
        else
        {
            goal = emptyGoal.position;
            //animator.SetBool("Atack", false);
        }

        Distance = Vector3.Distance(transform.position, goal);
        //print(distance);
        //Si la distancia al objetivo es menor 

        if (Distance > 1f)
        {
            agent.speed = 2f;
        }
        else
        {
            agent.speed = 0f;
        }

        agent.SetDestination(goal);




    }



    void Detectar()
    {
        Vector3 playerPosition = survivor.position;
        Vector3 vectorToPlayer = playerPosition - transform.position;

        float distancetoPlayer = Vector3.Distance(transform.position, playerPosition);
        float angleToPlayer = Vector3.Distance(transform.forward, vectorToPlayer);

        if (distancetoPlayer <= visionRange && angleToPlayer <= visionConeAngle)
        {
            if (!pillado)
            {

                Detected = true;
                pillado = true;
            }

        }
        else
        {
            if (pillado)
            {
                Detected = false;
                pillado = false;
            }


        }

        if (distancetoPlayer < 4f)
        {

            //animator.SetBool("IsInRange", true);

        }
        else
        {
            // animator.SetBool("IsInRange", false);
        }



    }

    IEnumerator Ronda()
    {
        while (!Detected)
        {
            float RandomX = Random.Range(-50f, 50f);
            float RandomZ = Random.Range(-50f, 50f);
            Vector3 randomPos = new Vector3(RandomX, 0, RandomZ);
            Vector3 destPos = transform.position + randomPos;

            yield return new WaitForSeconds(7f);

            emptyGoal.transform.position = destPos;
        }

    }

}
