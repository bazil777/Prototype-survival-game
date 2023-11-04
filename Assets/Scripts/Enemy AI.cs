using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    public GameObject target; // Change this from Transform to GameObject

    public float chaseRange = 15f;
    public float moveSpeed = 3.0f;
    public float contactRange = 1.0f; // Define the contact range for the enemy.
    public float attackCooldown = 2.0f; // Time to wait between attacks.

    public Material chasingMaterial; // Assign chasing in the Inspector.

    public int damageAmount = 5;
    public int maxHealth = 50; // Maximum health of the enemy

    private Material originalMaterial;
    private Renderer coneRenderer;
    private bool canAttack = true;
    private int currentHealth; // Current health of the enemy

    public PlayerGold playerGold; // Reference to the PlayerGold script

    void Start()
    {
        // Initialize the coneRenderer and originalMaterial.
        coneRenderer = GetComponent<Renderer>();
        originalMaterial = coneRenderer.material;
        currentHealth = maxHealth; // Set the current health to the maximum health at the start.
    }

    void Update()
    {
        if (target == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToPlayer <= chaseRange)
        {
            coneRenderer.material = chasingMaterial;
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Check if the enemy is in contact with the player and can attack.
            if (distanceToPlayer < contactRange && canAttack)
            {
                // Deal damage to the player.
                target.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

                // Start the attack cooldown.
                StartCoroutine(AttackCooldown());
            }
        }
        else
        {
            coneRenderer.material = originalMaterial;
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       
        // Destroy the enemy GameObject.
        Destroy(gameObject);
    }
}
