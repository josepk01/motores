using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxHeight = 5f;

    private void Update()
    {
        // Mover la bala hacia arriba
        transform.position += Vector3.up * speed * Time.deltaTime;

        // Destruir cuando supera cierto valor
        if (transform.position.y > maxHeight)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Blowup bubble = collision.gameObject.GetComponent<Blowup>();
        if (bubble != null)
        {
            bubble.Burst();
            Destroy(gameObject); // Destruir la bala
        }
    }
}
