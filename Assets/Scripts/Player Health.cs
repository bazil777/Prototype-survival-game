using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 60; // Initial health value
    public Material deathMaterial; // Reference to the material to use when health reaches 0 (may not apply in prototype as not core but will need to do something on death in final game )
    public int maxHealth = 100; // The maximum health value
    public GameObject damageParticlesPrefab; // Creates particles, used below to when player is hit
    private Renderer capsuleRenderer;
    private Material originalMaterial;

    private void Start()
    {
        capsuleRenderer = GetComponent<Renderer>(); 
        originalMaterial = capsuleRenderer.material;
    }

    // Method for taking damage
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0; // Ensure health doesn't go negative
            //if it is less than zero then call death function(atm it does nothing but in the game it will.)
            OnPlayerDeath();
        }
        Instantiate(damageParticlesPrefab, transform.position, Quaternion.identity);
        UpdateMaterial();
    }

    // Method for healing
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth; // Cap health at the maximum value
        }
        UpdateMaterial();
    }

    // Change the material when health reaches 0
    private void OnPlayerDeath()
    {
        capsuleRenderer.material = deathMaterial;
        // in the final game we will ad dmore actions here, like a visual que for death
    }

    // Update the material to the original when health changes
    private void UpdateMaterial()
    {
        capsuleRenderer.material = originalMaterial;
    }

    // Method to increase health
    public void IncreaseHealth(int increaseAmount)
    {
        Heal(increaseAmount);
    }
}
