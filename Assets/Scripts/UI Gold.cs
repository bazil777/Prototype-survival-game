using UnityEngine;
using TMPro;

public class UIGold : MonoBehaviour
{
    public PlayerGold playerGold;
    private TextMeshProUGUI goldText;

    private void Start()
    {
        goldText = GetComponentInChildren<TextMeshProUGUI>();

        if (goldText == null)
        {
            goldText = gameObject.AddComponent<TextMeshProUGUI>();
            goldText.fontSize = 24;
            goldText.color = Color.white;
        }
    }

    private void Update()
    {
        if (playerGold != null && goldText != null)
        {
            goldText.text = "Gold: " + playerGold.currentGold.ToString();
        }
    }
}
