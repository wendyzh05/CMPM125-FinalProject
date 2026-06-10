using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin Triggered!");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected coin!");

            CoinManager.instance.AddCoins(coinValue);

            Destroy(gameObject);
        }
    }
}