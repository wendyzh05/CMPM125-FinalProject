using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TMP_Text coinText;

    private int coins = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddCoins(int amount)
    {
        coins += amount;

        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }

        ObjectivesUI objectivesUI = FindFirstObjectByType<ObjectivesUI>();

        if (objectivesUI != null)
        {
            objectivesUI.CoinCollected();
        }
    }
}