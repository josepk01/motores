using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private int minBubbles = 3;
    [SerializeField] private int maxBubbles = 5;
    [SerializeField] private Transform leftWall; // Referencia al muro izquierdo
    [SerializeField] private Transform rightWall; // Referencia al muro derecho
    [SerializeField] private Transform roof; // Referencia al techo
    [SerializeField] private Transform floor; // Referencia al suelo
    [SerializeField] private float minForce = 2f;
    [SerializeField] private float maxForce = 5f;

    private void Start()
    {
        SpawnBubbles();
    }

    private void SpawnBubbles()
    {
        int numberOfBubbles = Random.Range(minBubbles, maxBubbles + 1);

        for (int i = 0; i < numberOfBubbles; i++)
        {
            // Genera una posición aleatoria entre los muros y dentro de la zona visible
            float xPosition = Random.Range(leftWall.position.x, rightWall.position.x);
            float yPosition = Random.Range(floor.position.y, roof.position.y);
            Vector2 spawnPosition = new Vector2(xPosition, yPosition);

            GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float randomMagnitude = Random.Range(minForce, maxForce);

            Blowup blowup = bubble.GetComponent<Blowup>();
            blowup.initialForceDirection = randomDirection;
            blowup.initialForceMagnitude = randomMagnitude;

            GameManager.Instance.OnBubbleCreated();
        }
    }
}
