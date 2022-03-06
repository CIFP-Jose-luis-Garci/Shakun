using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    public static bool HasFinished2 = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            SceneManager.LoadScene(6);

            HasFinished2 = true;
        }
    }



}
