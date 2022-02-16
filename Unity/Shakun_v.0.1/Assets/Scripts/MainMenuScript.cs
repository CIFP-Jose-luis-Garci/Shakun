using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public void Jugar()
    {
        ShonuMove.Vida = 50;
        ShonuMove.Alive = true;
        SceneManager.LoadScene(3);
    }

    public void Opciones()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
