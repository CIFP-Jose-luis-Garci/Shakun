using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShonuManage : MonoBehaviour
{

    public static int Vida = 50;
    public static int Mana = 100;

    public static bool Alive = true;

    public static int ShonuForm = 1;



    [SerializeField] GameObject ShonuN, ShonuA;


    InputControl inputcontrol;

    private void Awake()
    {
        inputcontrol = new InputControl();


        inputcontrol.ChangeKit.Water.started += _ => ChangeToWater();

        inputcontrol.ChangeKit.Normal.started += _ => ChangeToNormal();
    }
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        ShonuA.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeToNormal()
    {
        ShonuN.gameObject.SetActive(true);
        ShonuA.gameObject.SetActive(false);

        ShonuForm = 1;
    }


    void ChangeToWater()
    {
        ShonuN.gameObject.SetActive(false);
        ShonuA.gameObject.SetActive(true);

        ShonuForm = 2;
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
