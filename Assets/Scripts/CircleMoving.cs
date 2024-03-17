using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;


public class CircleMoving : MonoBehaviour
{
    public Rigidbody2D theRB;

    //public SpriteRenderer theSR;

    public float speed, jumpForce;

    public GameObject Vikingo;


    public bool canDoubleJump;

    public Animator animator;

    [Header("Grounded")]
   public Transform groundCheckpoint;
   
    public LayerMask whatIsGround;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento adelante atras
        theRB.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        //hace que se voltee el script del player cuando se camina hacia atras
        if (theRB.velocity.x < 0)
        {
            //theSR.flipX = true;

            //Hace que el hijo de vuelta
            float newrot = 180;
            Vikingo.transform.localEulerAngles = new Vector3(Vikingo.transform.localEulerAngles.x, newrot, Vikingo.transform.localEulerAngles.z);
        }
        else if (theRB.velocity.x > 0)
        {
            //theSR.flipX = false;

            //Hace que el hijo de vuelta
            float newrot = 0;
            Vikingo.transform.localEulerAngles = new Vector3(Vikingo.transform.localEulerAngles.x, newrot, Vikingo.transform.localEulerAngles.z);
        }

        //sabe si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);


        if (isGrounded)
        { //complementa el doble salto
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump")) //regula el salto
        {
            if (isGrounded)
            {//el if evita el salto infinito
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce); //función de salto 
            }
            else
            {
                if (canDoubleJump)
                { //regula el doble salto
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
        animator.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));




    }

}
