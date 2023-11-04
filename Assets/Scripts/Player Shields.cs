using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public int shieldAmount = 100; // Initial shield value
    public Material brokenShieldMaterial; // Reference to the material to use when shields are broken
    public int maxShield = 100; // The maximum shield value

    private Renderer shieldRenderer;
    private Material originalShieldMaterial;

    private void Start()
    {
        shieldRenderer = GetComponent <Renderer>(); // Attach this script to your shield GameObject with a Renderer component
        originalShieldMaterial = shieldRenderer.material;
    }

    // Method for taking damage to the shields
    public void TakeShieldDamage(int damageAmount)
    {
        shieldAmount -= damageAmount;
        if (shieldAmount <= 0)
        {
            shieldAmount = 0; // Ensure shield amount doesn't go negative
            // Handle broken shields or other game logic here
            OnShieldsBroken();
        }
        UpdateShieldMaterial();
    }

    // Method for recharging shields
    public void RechargeShields(int rechargeAmount)
    {
        shieldAmount += rechargeAmount;
        if (shieldAmount > maxShield)
        {
            shieldAmount = maxShield; // Cap shield amount at the maximum value
        }
        UpdateShieldMaterial();
    }

    // Change the material when shields are broken
    private void OnShieldsBroken()
    {
        shieldRenderer.material = brokenShieldMaterial;
        // You can add more actions for broken shields here
    }

    // Update the material to the original when shield amount changes
    private void UpdateShieldMaterial()
    {
        shieldRenderer.material = originalShieldMaterial;
    }

    // Method to increase shields
    public void IncreaseShields(int increaseAmount)
    {
        RechargeShields(increaseAmount);
    }
}
