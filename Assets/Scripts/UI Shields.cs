using UnityEngine;
using TMPro;

public class ShieldUI : MonoBehaviour
{
    public ShieldController shieldController;
    private TextMeshProUGUI shieldText;

    [Header("Text Settings")]
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.red; // Change this to the desired color for inactive shields

    private void Start()
    {
        if (shieldController == null)
        {
            Debug.LogError("ShieldController script reference not set in ShieldUI.");
        }

        shieldText = GetComponentInChildren<TextMeshProUGUI>();

        if (shieldText == null)
        {
            shieldText = gameObject.AddComponent<TextMeshProUGUI>();
            shieldText.font = Resources.Load<TMP_FontAsset>("YourCustomFontName");
            shieldText.fontSize = 24;
        }
    }

    private void Update()
    {
        if (shieldController != null && shieldText != null)
        {
            shieldText.text = "Shields: " + shieldController.shieldAmount.ToString();

            // Check if shields are depleted (shield amount is 0)
            if (shieldController.shieldAmount == 0)
            {
                shieldText.color = inactiveColor; // Change the color to indicate inactive shields
            }
            else
            {
                shieldText.color = activeColor; // Change the font color to indicate an active shield
            }
        }
    }
}
