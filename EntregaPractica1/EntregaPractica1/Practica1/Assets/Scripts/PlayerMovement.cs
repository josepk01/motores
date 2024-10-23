using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private GameObject paredIzq;
    [SerializeField]
    private GameObject paredDer;
    
    private float anchoJugador;
    private float anchoPared;
    private float posParedIzq;
    private float posParedDer;
    Vector3 futurePos;
    private Shoot shot;

    bool onCooldown=false;
    float cdTime = 0.5f;
    float cdTimeStart = 0.0f;
    float timeC;
   
    bool isOnFloor;
    // Start is called before the first frame update
    void Start()
    {
        anchoJugador = GetComponentInChildren<Transform>().localScale.x;
        shot = GetComponentInChildren<Shoot>();  //quien dispara es el arma
        anchoPared = paredIzq.GetComponent<Transform>().localScale.x; //las 2 paredes tienen el mismo ancho
        posParedIzq = paredIzq.GetComponent<Transform>().position.x; //paredIzquierda
        posParedDer = paredDer.GetComponent<Transform>().position.x; //paredDerecha
        futurePos = transform.position;
        timeC = cdTimeStart;
        
    }
   

    // Update is called once per frame
    void Update()
    {
       
        float distanciaMin = anchoJugador / 2 + anchoPared / 2;
        futurePos = transform.position;
       
        if (Input.GetKey(KeyCode.RightArrow) && (posParedDer - transform.position.x >= distanciaMin))
        {
            //si se pasa en el siguiente movimiento no lo mueve, pero si esta cerca lo deja en el limite
            futurePos += futurePos*speed*Time.deltaTime;
            if (posParedDer - futurePos.x > distanciaMin)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                
            }
            else
            {
                transform.position=new Vector3(posParedDer-distanciaMin, transform.position.y, 0);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && (transform.position.x - posParedIzq >= distanciaMin))
        {
            //si se pasa en el siguiente movimiento no lo mueve, pero si esta cerca lo deja en el limite
            futurePos += futurePos* speed * Time.deltaTime;
            if (futurePos.x - posParedIzq > distanciaMin)
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                //Debug.Log(futurePos.x - posPared1);
            }
            else
            {
                transform.position = new Vector3(posParedIzq+distanciaMin, transform.position.y, 0);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!onCooldown)
            {
                shot.SpawnBullet();
                onCooldown = true;
            }
            
        }
        if(onCooldown)
        {
            timeC += Time.deltaTime;
            if (timeC > cdTime) {
                onCooldown=false;
                timeC = cdTimeStart;
            }

        }
       
        
    }
}
