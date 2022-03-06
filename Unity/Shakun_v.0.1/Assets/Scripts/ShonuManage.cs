using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShonuManage : MonoBehaviour
{

    public static int Vida = 50;
    public static float MainMana = 100;

    public static bool Alive = true;

    public static int ShonuForm = 1;

    public static bool IsAttacking = false;

    [SerializeField] GameObject ShonuN, ShonuA;


    InputControl inputcontrol;

    int Invuln = 5;

    public static int spawn = 1;


    private void Awake()
    {
        inputcontrol = new InputControl();




        inputcontrol.ChangeKit.Water.started += _ => ChangeToNormal();

        inputcontrol.ChangeKit.Normal.started += _ => ChangeToWater();
    }
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        ShonuA.gameObject.SetActive(false);

        StartCoroutine("ManaRegen");

    }

    // Update is called once per frame
    void Update()
    {
        


        if (ShonuForm == 1)
        {
            ShonuA.transform.position = ShonuN.transform.position;
        }
        if (ShonuForm == 2)
        {
            
            ShonuN.transform.position = ShonuA.transform.position;
        }

        
    }

    void TookDamage(int DamageTaken)
    {
        if (Invuln >= 5)
        {
            Vida -= DamageTaken;


            Invuln = 0;

            StartCoroutine("InvulnTime");
        }




        if (Vida <= 0)
        {
            Alive = false;

            StartCoroutine("ShonuDeath");
        }
    }

    IEnumerator InvulnTime()
    {
        while (Invuln < 5)
        {
            Invuln += 1;

            yield return new WaitForSeconds(0.3f);
        }


    }

    IEnumerator ShonuDeath()
    {
        yield return new WaitForSeconds(4);


        SceneManager.LoadScene(8);
    }


    void ChangeToNormal()
    {
        
            print("AA");

            ShonuN.gameObject.SetActive(true);
            ShonuA.gameObject.SetActive(false);

            ShonuForm = 1;
        

        
    }


    void ChangeToWater()
    {
        
        
            print("BB");
            ShonuN.gameObject.SetActive(false);
            ShonuA.gameObject.SetActive(true);

            ShonuForm = 2;
        


       
        
    }

    IEnumerator ManaRegen()
    {
        while (true)
        {
            

            MainMana += 0.6f;

            yield return new WaitForSeconds(0.3f);
        }
    }



    private void OnEnable()
    {
        inputcontrol.Enable();
    }

    private void OnDisable()
    {
        inputcontrol.Disable();
    }



}
