using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private bool hasHitPlayer = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        transform.position = startPosition + Vector3.up * yOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasHitPlayer) return;

        if (other.CompareTag("Player"))
        {
            hasHitPlayer = true;

            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.LoseLife();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasHitPlayer = false;
        }
    }
}