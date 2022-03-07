using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    //reference Attack Point
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextattackTime = 0f;

    // Update is called once per frame
    void Update()
    {
       //Player should attack with the A button on computer
        if(Time.time >= nextattackTime)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Attack();
                nextattackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range
        Collider2d[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    //Allows to draw in the editor when object is selected
    private void OnDrawGizmosSelected()
    {
        //if attack point has not been assigned
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange)
    }
}
