using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavmeshEnable : MonoBehaviour
{
    GameObject Enemy;


    private void Start()
    {
        Enemy = gameObject.transform.GetChild(0).gameObject;
    }


    void EnableNavMesh()
    {
        print("AAAawmd");
        
        Enemy.GetComponent<NavmeshEnable>();
    }
}
