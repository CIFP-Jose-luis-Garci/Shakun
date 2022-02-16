using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    public void Volver()
    {
        
        ShonuMove.Vida = 50;
        ShonuMove.Alive = true;
        SceneManager.LoadScene(3);
        
    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }


}
