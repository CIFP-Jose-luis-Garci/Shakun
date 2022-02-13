using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEvent : MonoBehaviour
{

    GameObject HudText, HudMoney;

    GameObject Shonu;

    public static bool WantsMoney = false;

    public Text CoinText;

    public static int CoinCount;


    // Start is called before the first frame update
    void Start()
    {
        HudText = GameObject.Find("Text");

        HudMoney = GameObject.Find("MoneyCounter");

      
        Shonu = GameObject.Find("Shonu 2");


        HudText.gameObject.SetActive(false);
        HudMoney.gameObject.SetActive(false);
    }

    private void Update()
    {
        CoinText.text =  "" +CoinCount;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            HudText.gameObject.SetActive(true);
            HudMoney.gameObject.SetActive(true);
            
            WantsMoney = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            HudText.gameObject.SetActive(false);
        }
    }




}
