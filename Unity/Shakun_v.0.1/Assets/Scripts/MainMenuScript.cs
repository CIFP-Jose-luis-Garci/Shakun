using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public void Jugar()
    {
        ShonuManage.Vida = 50;
        ShonuManage.Alive = true;
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
