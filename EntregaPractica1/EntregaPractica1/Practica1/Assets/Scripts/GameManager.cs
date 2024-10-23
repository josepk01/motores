using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    //En caso de querer jugar con vidas
    [SerializeField]
    private int lives = 3;

    private int numpompas;
    private bool finished=false;

    [SerializeField]
    GameObject player;
    [SerializeField]
    UIManager uimng;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        numpompas = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si te quedas sin vidas pierdes
        if (lives <= 0 &&player!=null&&!finished)
        {
            //fin del juego
            uimng.Inform("Has Perdido");
            Destroy(player);
            finished = true;
            Debug.Log(player==null);
        }
        //if (player == null)
        //{
        //    Debug.Log("destruido");
        //}
        if (numpompas == 0 && !finished)
        {
            uimng.Inform("Has Ganado");
            finished = true;
        }

    }

    public void OnPlayerDamaged()
    {
        if (!finished)
        {
            lives--;
            Debug.Log(lives);
        }
    }

    public void OnBubbleCreated()
    {
        numpompas++;
    }

    public void OnBubbleDamaged()
    {
        
        numpompas--;
       
    }

    public int getLives()
    {
        return lives;
    }


}
