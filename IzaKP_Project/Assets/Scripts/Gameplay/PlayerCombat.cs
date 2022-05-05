using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;


    //reference Attack Point
    public Transform attackPoint;
    public LayerMask enemyLayers;
    //public LayerMask playerLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 3;

    public float attackRate = 2f;
    float nextattackTime = 0f;

    public float blockRange = 0.5f;
    public float blockRate = 2f;
    float nextblockTime = 0f;

    public bool isAiControlled;
    public bool isBlocking;
   

    // Update is called once per frame
    void Update()
    {
       //Player should attack with the A button on computer
        //if(Time.time >= nextattackTime)-no longer needed
        //connected to A button on touch screen
            if (Input.GetKeyDown(KeyCode.A) && !isAiControlled)
            {
            OnAttackPressed();
            }

        //Player should block with the B button on touch screen
        if (Input.GetKeyDown(KeyCode.B) && !isAiControlled)
        {
            OnBlockPressed();
        }
    } 

    public void OnAttackPressed() 
    {

        if (Time.time >= nextattackTime)
        {
            Attack();
            nextattackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");
        Debug.Log("Attacking...");
       
        //Detect enemies in range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            
        //Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
           
            enemy.GetComponent<PlayerHealth>()?.TakeDamage(2);
            }
    }

    //Allows to draw in the editor when object is selected
    private void OnDrawGizmosSelected()
    {
        //if attack point has not been assigned
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    public void OnBlockPressed()
    {
        if (Time.time >= nextblockTime)
        {
            Block();
            nextblockTime = Time.time + 1f / blockRate;
        }
    }

    void Block()
    {
        //Play block animation
        animator.SetTrigger("Block");

        Debug.Log("Blocked!");
        isBlocking = true;
        StartCoroutine(BlockRoutine());

        //Detect enemies in range
        //Collider2D[] shieldPlayer = Physics2D.OverlapCircleAll(attackPoint.position, blockRange, playerLayer);

        //block enemy attacks from causing damage
        //foreach (Collider2D player in shieldPlayer)
        //{
        // player.GetComponent<PlayerHealth>().TakeDamage(0);
        //}

    }

    IEnumerator BlockRoutine()
    {
        yield return null;
        yield return new WaitForSeconds(1f);
        isBlocking = false;
    }
  
}
