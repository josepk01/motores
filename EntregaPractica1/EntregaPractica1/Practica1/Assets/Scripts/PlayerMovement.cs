using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float playerWidth = 0.5f;  // Grosor del jugador
    [SerializeField] private float playAreaWidth = 16f; // Ancho visible (-8 a 8)
    [SerializeField] private float wallThickness = 0.5f; // Grosor de las paredes

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        // Limitar movimiento dentro del área visible
        float halfWidth = playAreaWidth / 2f - wallThickness - playerWidth / 2f;
        newPosition.x = Mathf.Clamp(newPosition.x, -halfWidth, halfWidth);

        transform.position = newPosition;
    }
}
