using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpcionesScript : MonoBehaviour
{
   public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
