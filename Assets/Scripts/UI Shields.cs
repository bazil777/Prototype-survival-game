using UnityEngine;
using TMPro;

public class ShieldUI : MonoBehaviour
{
    public ShieldController shieldController; // Reference to the ShieldController script on the player or shield object
    private TextMeshProUGUI shieldText; // Reference to the TextMeshProUGUI component

    private void Start()
    {
        if (shieldController == null)
        {
            Debug.LogError("ShieldController script reference not set in ShieldUI.");
        }

        // Try to find a TextMeshProUGUI component on the current GameObject
        shieldText = GetComponentInChildren<TextMeshProUGUI>();

        // If a TextMeshProUGUI component is not found, create one
        if (shieldText == null)
        {
            shieldText = gameObject.AddComponent<TextMeshProUGUI>();
            shieldText.font = Resources.Load<TMP_FontAsset>("YourCustomFontName"); // Load your custom font
            shieldText.fontSize = 24; // Set the font size
            shieldText.color = Color.black; // Set the text color
        }
    }

    private void Update()
    {
        if (shieldController != null && shieldText != null)
        {
            shieldText.text = "Shields: " + shieldController.shieldAmount.ToString();
        }
    }
}

