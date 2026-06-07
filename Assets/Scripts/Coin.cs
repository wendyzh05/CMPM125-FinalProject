using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
