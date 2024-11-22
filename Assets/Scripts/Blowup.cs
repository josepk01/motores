using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blowup : MonoBehaviour
{
    [SerializeField]
    private Vector3 initialForceDirection;
    [SerializeField]
    private int initialForceMagnitude = 5;
    [SerializeField]
    private GameObject child;
    [SerializeField]
    private float divisionMod;
    [SerializeField]
    private float minTam;

    bool velSet = false;


    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        Init(initialForceDirection, transform.localScale, false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(Vector2 initalDir, Vector2 tam, bool esHija)
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (esHija)
        {
            transform.localScale = tam;

            if (rb2d != null)
            {


                rb2d.AddForce(initalDir.normalized * initialForceMagnitude);
            }
            velSet = true;

        }
        else
        {
            if (rb2d != null && !velSet)
            {

                rb2d.AddForce(initialForceDirection.normalized * initialForceMagnitude);
            }

        }
        GameManager.Instance.OnBubbleCreated();

    }

    //cuando explota
    public void Burst()
    {

        //GameManager.instance.OnBubbleDestroyed();
        //Destroy(this.gameObject);

        Split();
        
    }

    private void Split()
    {
        if (transform.localScale.x > minTam)
        {
            GameObject sucessor = child;
            Vector2 newTam = transform.localScale * divisionMod;

            Vector2 izq = new Vector2(-1, 1);
            Vector2 der = new Vector2(1, 1);
            GameObject pompa1 = Instantiate(sucessor, transform.position, transform.rotation);
            pompa1.GetComponent<Blowup>().Init(izq, newTam, true);
            GameObject pompa2 = Instantiate(sucessor, transform.position, transform.rotation);
            pompa2.GetComponent<Blowup>().Init(der, newTam, true);


        }

        GameManager.Instance.OnBubbleDestroyed();
        Destroy(this.gameObject);
    }


}




/*
 private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = initialForceDirection.normalized * initialForceMagnitude;
        rb.AddForce(force, ForceMode2D.Impulse);
        GameManager.Instance.OnBubbleCreated();
    }
 
 
 
 */