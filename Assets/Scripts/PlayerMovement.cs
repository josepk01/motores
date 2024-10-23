using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
//---otra opcion de mov
//// Update is called once per frame
//void Update()
//{

//    float distanciaMin = anchoJugador / 2 + anchoPared / 2;
//    futurePos = transform.position;

//    if (Input.GetKey(KeyCode.RightArrow) && (posParedDer - transform.position.x >= distanciaMin))
//    {
//        //si se pasa en el siguiente movimiento no lo mueve, pero si esta cerca lo deja en el limite
//        futurePos += futurePos * speed * Time.deltaTime;
//        if (posParedDer - futurePos.x > distanciaMin)
//        {
//            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);

//        }
//        else
//        {
//            transform.position = new Vector3(posParedDer - distanciaMin, transform.position.y, 0);
//        }
//    }
//    else if (Input.GetKey(KeyCode.LeftArrow) && (transform.position.x - posParedIzq >= distanciaMin))
//    {
//        //si se pasa en el siguiente movimiento no lo mueve, pero si esta cerca lo deja en el limite
//        futurePos += futurePos * speed * Time.deltaTime;
//        if (futurePos.x - posParedIzq > distanciaMin)
//        {
//            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
//            //Debug.Log(futurePos.x - posPared1);
//        }
//        else
//        {
//            transform.position = new Vector3(posParedIzq + distanciaMin, transform.position.y, 0);
//        }
//    }

//    if (Input.GetKey(KeyCode.Space))
//    {
//        if (!onCooldown)
//        {
//            shot.SpawnBullet();
//            onCooldown = true;
//        }

//    }
//    if (onCooldown)
//    {
//        timeC += Time.deltaTime;
//        if (timeC > cdTime)
//        {
//            onCooldown = false;
//            timeC = cdTimeStart;
//        }

//    }


//}
//}