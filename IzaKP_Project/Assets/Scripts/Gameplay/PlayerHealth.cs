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

    public GameObject gameOverMenuUI;

    public GameObject winMenuUI;


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

        //if statement for when health reaches zero triggers Die()
        if (currentHealth == 0)
        {
            Die();
            //show lose or win screen
            //game over
            FindObjectOfType<GameManager>().EndGame();
            gameOverMenuUI.SetActive(true);
        }
    }

    //if statement for when one character's health reaches 0 before the other
    //public void Victory()
    //{
        //Win();
        //winMenuUI.SetActive(true);
    //}

    void Die()
    {
        //Die animation
        animator.SetTrigger("Lose");

        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    void Win()
    {
        //win animation
        animator.SetTrigger("Win");

        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
