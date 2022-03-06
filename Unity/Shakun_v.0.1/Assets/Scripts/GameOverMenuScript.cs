using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    public void Volver()
    {
        
        ShonuManage.Vida = 50;
        ShonuManage.MainMana = 100;
        ShonuManage.Alive = true;
        
        if(ShonuManage.spawn == 1)
        {
            SceneManager.LoadScene(3);

            ShopEvent.CoinCount = 0;
        }

       else if (ShonuManage.spawn == 2)
        {
            SceneManager.LoadScene(4);
        }

       else if (ShonuManage.spawn == 3)
        {
            SceneManager.LoadScene(6);
        }

    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }


}
