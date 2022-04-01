using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This script allows user to move player left and right on touch screen
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private float moveSpeed;
    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 10f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (touch.position.x < Screen.width / 2)
                        rb.velocity = new Vector2(- moveSpeed, 0f);

                    if (touch.position.x > Screen.width / 2)
                        rb.velocity = new Vector2(moveSpeed, 0f);
                    break;

                case TouchPhase.Ended:
                    rb.velocity = new Vector2(0f, 0f);
                    break;
            }
        }

        //Brackey's tutorial on joystick movement
        horizontalMove = joystick.Horizontal * runSpeed;

    }
}
