using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    public void Volver()
    {
        
        ShonuManage.Vida = 50;
        ShonuManage.Alive = true;
        
        if(ShopEvent.HasFinished = true && TeleportScript.HasFinished2 == false)
        {
            SceneManager.LoadScene(4);
        }

        if (ShopEvent.HasFinished = true && TeleportScript.HasFinished2 == true)
        {
            SceneManager.LoadScene(6);
        }

        if (ShopEvent.HasFinished = false && TeleportScript.HasFinished2 == false)
        {
            SceneManager.LoadScene(3);
        }

    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }


}
