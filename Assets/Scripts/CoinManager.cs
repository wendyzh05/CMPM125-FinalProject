using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TMP_Text coinText;

    private int coins = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = "Coins: " + coins;

        if (ObjectiveManager.instance != null)
        {
            ObjectiveManager.instance.CoinCollected();
        }
    }
}