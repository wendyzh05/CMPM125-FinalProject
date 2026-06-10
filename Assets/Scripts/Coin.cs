using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip coinSound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin Triggered!");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected coin!");

            CoinManager.instance.AddCoins(coinValue);

            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    coinSound,
                    transform.position,
                    1f
                );
            }

            Destroy(gameObject);
        }
    }
}