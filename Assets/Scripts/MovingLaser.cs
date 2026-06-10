using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        transform.position = startPosition + Vector3.up * yOffset;
    }
}