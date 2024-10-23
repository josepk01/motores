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

        ////-------------OPCIONAL----------------
        ////PROTOTIPO DE FALSA DIVISION DE POMPAS (la nueva pompa llega a dividirse infinitamente)
        //if (timesBroken < maxBreaks)
        //{
        //    GameObject sucessor = child;
        //    sucessor.transform.localScale *= 0.5f;
        //    timesBroken++;

        //    Instantiate(sucessor, transform.position, transform.rotation);
        //}
        //else
        //{
        //    GameManager.instance.OnBubbleDamaged();
        //    Destroy(this.gameObject);
        //}
    }
}
