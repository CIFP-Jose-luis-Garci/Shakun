using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShonuMove : MonoBehaviour
{
    InputControl inputcontrol;

    bool corriendo = false;
   // bool camninado = false;

    Vector2 stickL;

    Animator animator;

    CharacterController cc;

    float speed;

    Vector3 dir;

    private void Awake()
    {
        inputcontrol = new InputControl();



        //Correr
        inputcontrol.Moverse.Run.performed += ctx => { corriendo = true; };
        inputcontrol.Moverse.Run.canceled += ctx => { corriendo = false; };

        //Caminar
        inputcontrol.Moverse.Move.performed += ctx => stickL = ctx.ReadValue<Vector2>();
        inputcontrol.Moverse.Move.canceled += ctx => stickL = Vector2.zero;


    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (corriendo && stickL.y > 0)
        {
            Correr();

        }
        else
        {
            Caminar();
        }

        //Giro
        transform.Rotate(new Vector3(0f, stickL.x * 0.8f, 0f));
    }

    void Correr()
    {
        animator.SetBool("RunShonu", true);
        speed = 5f;
        dir = transform.TransformDirection(Vector3.forward);
        cc.SimpleMove(dir * speed * stickL.y);
    }
    void Caminar()
    {
        
        animator.SetBool("RunShonu", false);
        animator.SetFloat("WalkShonu", stickL.y);

        if (stickL.y > 0)
        {
            speed = 2.2f;
        }
        else
        {
            speed = 0.8f;
        }

        dir = transform.TransformDirection(Vector3.forward);

        cc.SimpleMove(dir * speed * stickL.y);
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
