using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    [SerializeField] GameObject Shonu, Parent;

    private GameObject[] Obstacle;


    // Start is called before the first frame update
    void Start()
    {
        Obstacle = GameObject.FindGameObjectsWithTag("ZombieSpawn");
    
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
