using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 12;
    public int currentHealth;

    public HealthBar healthBar;

    public bool isAiControlled;

    public Animator animator;

    //Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Test to see if health bar moves at all
        //Health bar should go down when hit by enemy
        if (Input.GetKeyDown(KeyCode.Space) && !isAiControlled)
        {
            TakeDamage(3);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        //play hurt animation
        animator.SetTrigger("Hurt");
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //Die animation
        animator.SetTrigger("Lose");

        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
