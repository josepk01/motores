using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int bubbleCount = 0;
    public UIManager uiManager;

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
        if (bubbleCount == 0)
        {
            uiManager.Inform("You Win!", Color.green);
        }
    }

    public void OnPlayerDamaged()
    {
        uiManager.Inform("You Lose!", Color.red);
    }
}
