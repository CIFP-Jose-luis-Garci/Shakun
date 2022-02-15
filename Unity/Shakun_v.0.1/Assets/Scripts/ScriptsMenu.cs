using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptsMenu : MonoBehaviour
{


    InputControl inputcontrol;

    public static bool PauseSwitch = false;
    bool PauseButton;

    public GameObject Overlay, PauseMenu, OpcionesMenu;

    private void Awake()
    {
        inputcontrol = new InputControl();
       
        //Pausa
        inputcontrol.Menu.Pausa.started += ctx => { PauseButton = true; };
        inputcontrol.Menu.Pausa.canceled += ctx => { PauseButton = false; };

    }


    // Start is called before the first frame update
    void Start()
    {
        

        Overlay = GameObject.Find("Overlay");
        PauseMenu = GameObject.Find("MenuPausa");
        OpcionesMenu = GameObject.Find("MenuOpciones");


        PauseMenu.SetActive(false);
        Overlay.SetActive(true);
        OpcionesMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ManagePause();
    }



    void ManagePause()
    {
        if(PauseButton == true)
        {
            

            PauseSwitch = true;

            Overlay.SetActive(false);
            PauseMenu.SetActive(true);

        }
    }



    public void VolverAlJuego()
    {
        Overlay.SetActive(true);
        PauseMenu.SetActive(false);

        PauseSwitch = false;
    }


    public void Opciones()
    {
        OpcionesMenu.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void OpcionesSalir()
    {
        OpcionesMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
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
