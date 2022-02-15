using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    public void Volver()
    {
        SceneManager.LoadScene(3);
    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }


}
