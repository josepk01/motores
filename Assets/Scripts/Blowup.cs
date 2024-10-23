using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Blowup : MonoBehaviour
{
    [SerializeField] public Vector2 initialForceDirection;
    [SerializeField] public float initialForceMagnitude;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = initialForceDirection.normalized * initialForceMagnitude;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void Burst()
    {
        GameManager.Instance.OnBubbleDestroyed();
        Destroy(gameObject);
    }
}
