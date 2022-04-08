using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 12;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator animator;

    //access health bar
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


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

        //Test to see if health bar reacts to damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

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

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
