using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    private float impulse = 10.0f;
    private float alturaMax = 5.0f;
    private Vector2 direction = Vector2.up;
    // Start is called before the first frame update
    void Start()
    {
        direction *= impulse;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*Time.deltaTime);
        if (transform.position.y > alturaMax)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Blowup>()!=null) {

            collision.gameObject.GetComponent<Blowup>().burst();
            Destroy(gameObject);
        }
    }

}


