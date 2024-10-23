using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void Harm()
    {
        GameManager.Instance.OnPlayerDamaged();
        Destroy(gameObject); // Destruir el jugador
    }
}
