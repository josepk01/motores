using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmful : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objectCol = collision.gameObject;
        if(objectCol.GetComponent<PlayerMovement>() != null) {
            if(objectCol.GetComponent<Health>()!= null)
            {
                objectCol.GetComponent<Health>().Harm();
            }
            
            Debug.Log("Choca");
            if (gameObject.GetComponent<Blowup>()!=null)
            {
                GameManager.instance.OnBubbleDamaged();
                Destroy(gameObject);
            }
                
           
        }
    }

  
}
