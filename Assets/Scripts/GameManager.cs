using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField]
    private int bubbleCount;
    [SerializeField]
    private UIManager uiManager;
    

    [SerializeField]
    private int lives = 1;
    [SerializeField]
    private Timer tmr;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance.gameObject);
        }
        bubbleCount = 0;
    }

    private void Start()
    {
        //if (gameObject.GetComponent<Timer>() != null)
        //{
        //    tmr = gameObject.GetComponent<Timer>();
        //    Debug.Log("Llega");
        //}
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
            PauseTimer();
            tmr.SetBestTime(tmr.GetCurrFloatTime());
        }
    }

    public void OnPlayerDamaged()
    {
        lives--;
        if (lives <= 0)
        {
            PauseTimer();
            uiManager.Inform("You Lose!", Color.red);
        }

    }
    public int getLives()
    {
        return lives;
    }

    public string GetStrTimer()
    {
        if (tmr != null)
        {
            return tmr.GetCurrTime();
        }
        else
        {
            return "No tiene el timer asignado";
        }

    }
    public string GetBestTime()
    {
        if (tmr != null)
        {
            
            return tmr.GetBestTime();
        }
        else
        {
            return "No tiene el timer asignado";
        }
    }

    public void setUiManager(UIManager uimg)
    {
        if(uiManager == null)
        {
            uiManager = uimg;
        }
    }

    public void restartBubbles()
    {
        bubbleCount = 0;
    }

    public void PauseTimer()
    {
        tmr.StopTimer();
    }
    public void ResumeTimer()
    {
        tmr.ResumeTimer();
    }
    public void RestartTimer()
    {
        tmr.RestartTimer();
    }

}
