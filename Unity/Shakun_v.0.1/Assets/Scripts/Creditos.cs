using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToEnd", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void WaitToEnd()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
