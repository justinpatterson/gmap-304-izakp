using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    
    public int maxHealth = 12;
    int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    //function allows player to damage enemy, which can be called from Player Combat script
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log("Enemy died");

            animator.SetBool("isDead", true);

            //Disable enemy
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }
}
