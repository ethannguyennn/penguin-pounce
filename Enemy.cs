using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public Animator animator;
    public pipeMoveScript associatedPipe;
    public logicManager logicManagerInstance;


    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        //play hurt animation

        if (currentHealth <= 0)
        {
            Die();

        }
    }


    void Die()

    {
        if (logicManagerInstance != null)
        {
            logicManagerInstance.addScore(1);
        }
        // Stop movement
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Stop rigidbody velocity
            rb.gravityScale = 0; // Stop gravity
        }

        // Disable collider
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Set animator parameter
        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }

        // Disable this script
        this.enabled = false;

        // Disable associated pipe script if not null
        if (associatedPipe != null)
        {
            associatedPipe.enabled = false;
        }
    }
   

}


