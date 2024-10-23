using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blowup : MonoBehaviour
{
    [SerializeField]
    private Vector3 initialForceDirection = Vector3.right;
    [SerializeField]
    private int initialForceMagnitude = 5;
    [SerializeField]
    private GameObject child;
    
    private int timesBroken;
    [SerializeField]
    private int maxBreaks;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        if(rb2d != null)
        {
            rb2d.AddForce(initialForceDirection.normalized*initialForceMagnitude);
        }
        GameManager.instance.OnBubbleCreated();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //cuando explota
    public void burst()
    {


        //Comentar si se descomenta lo opcional
        GameManager.instance.OnBubbleDamaged();
        Destroy(this.gameObject);


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
