using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPlayerController : MonoBehaviour
{
    public PlayerCombat myCombat;
    public PlayerHealth myHealth;
    public PlayerMovement myMovement;
    public PlayerCharacterLoader myCharacterLoader;

    public GameObject playerTarget;

    public float aiMovementSpeed = 1f;
    public float attackDistance = 1f;


    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if(myHealth.currentHealth <= 0)
        {
            return;
        }

        if (IsInAttackRangeOfPlayer())
        {
            //attack
            myCombat.OnAttackPressed();
            myMovement.aiHorizontal = 0f;
        }
        else
        {
            //move TOWARD player.
            Vector3 moveDirection = playerTarget.transform.position - transform.position;
            float horizontalMovement = moveDirection.x;

            //if we want a speed up solution
            horizontalMovement = Mathf.Clamp(horizontalMovement, -aiMovementSpeed, aiMovementSpeed);
            myMovement.aiHorizontal = Mathf.Lerp(myMovement.aiHorizontal, horizontalMovement, Time.deltaTime * 2f);


        }
    }
    bool IsInAttackRangeOfPlayer()
    {
        return Vector3.Distance(transform.position, playerTarget.transform.position) < attackDistance;
    }
     

}
