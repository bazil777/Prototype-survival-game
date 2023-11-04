using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script on the capsule
    private TextMeshProUGUI healthText; // Reference to the TextMeshProUGUI component

    private void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth script reference not set in HealthUI.");
        }

        // Try to find a TextMeshProUGUI component on the current GameObject
        healthText = GetComponentInChildren<TextMeshProUGUI>();

        // If a TextMeshProUGUI component is not found, create one
        if (healthText == null)
        {
            healthText = gameObject.AddComponent<TextMeshProUGUI>();
            healthText.font = Resources.Load<TMP_FontAsset>("YourCustomFontName"); // Load your custom font
            healthText.fontSize = 24; // Set the font size
            healthText.color = Color.white; // Set the text color
        }
    }

    private void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "Health: " + playerHealth.health.ToString();
        }
    }
}


