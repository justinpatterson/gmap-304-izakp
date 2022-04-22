using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This script allows user to move player left and right on touch screen
    // Start is called before the first frame update

    private Rigidbody2D rb;
    public Joystick joystick;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;

    public bool isAiControlled;
    public float aiHorizontal = 0f;

    public Animator animator;

   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // moveSpeed = 10f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Brackey's tutorial on joystick movement
        horizontalMove = isAiControlled ? aiHorizontal : joystick.Horizontal * runSpeed;
        rb.velocity = new Vector2(horizontalMove, 0);

        animator.SetTrigger("Walk");
    }
}
