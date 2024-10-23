using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int bubbleCount = 4;
    public UIManager uiManager;

    [SerializeField]
    private int lives = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void OnBubbleCreated()
    {
        bubbleCount++;
    }

    public void OnBubbleDestroyed()
    {
        bubbleCount--;
        if (bubbleCount <= 0)
        {
            uiManager.Inform("You Win!", Color.green);
        }
    }

    public void OnPlayerDamaged()
    {
        lives--;
        if (lives <= 0)
        {

            uiManager.Inform("You Lose!", Color.red);
        }

    }
    public int getLives()
    {
        return lives;
    }
}
