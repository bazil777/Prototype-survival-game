using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public float healingRadius = 3f; // Radius within which the player is healed
    public int healingAmount = 5; // Amount of health to restore on contact
    public int goldDeductionAmount = 10; // Amount of gold to deduct on contact
    public float healingInterval = 1f; // Time interval between healing (adjust as needed)

    private float nextHealTime;

    private void Start()
    {
        nextHealTime = Time.time + healingInterval;
    }

    private void Update()
    {
        if (Time.time >= nextHealTime)
        {
            // Find all colliders within the healing radius
            Collider[] colliders = Physics.OverlapSphere(transform.position, healingRadius);

            foreach (Collider collider in colliders)
            {
                // Check if the collider belongs to the player
                PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
                PlayerGold playerGold = collider.GetComponent<PlayerGold>();

                if (playerHealth != null)
                {
                    // Heal the player if they are in the healing radius
                    playerHealth.Heal(healingAmount);

                    if (playerGold != null)
                    {
                        // Deduct gold from the player
                        playerGold.DeductGold(goldDeductionAmount);
                    }
                }
            }

            // Set the time for the next healing event
            nextHealTime = Time.time + healingInterval;
        }
    }
}
