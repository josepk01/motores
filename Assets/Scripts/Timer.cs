using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float timer = 0;
    private int min;
    private int sec;
    
    private int bestMin;
    private int bestSec;
    private bool tmUpdate = false;
    private float bestTime = -1f;
    // Start is called before the first frame update
    void Start()
    {

        timer = 0;
        //ResumeTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (tmUpdate) { 
            timer += Time.deltaTime;
            
            ConvertTime();
        }
    }

    private void ConvertTime()
    {
        int secTot = (int)timer;
        Debug.Log(secTot);

        min = secTot / 60;
        Debug.Log("Minutos" + min);
        sec =secTot % 60;
        Debug.Log("Segundos" + sec);

    }

    public void RestartTimer()
    {
        timer = 0;
    }
    public void StopTimer()
    {
        tmUpdate = false;
    }
    public void ResumeTimer()
    {
        tmUpdate = true;
    }

    public string GetBestTime()
    {
        if (bestTime > 0)
        {
            string bestMinStr;
            string bestSecStr;

            bestMinStr = SetTimeToString((int)bestTime / 60);

            bestSecStr = SetTimeToString((int)bestTime % 60);
           

            return bestMinStr + ":" + bestSecStr;
        }
        else
            return " ";
    }

    public void SetBestTime(float time)
    {
        if(time < bestTime || bestTime == 0)
        {
            bestTime = time;
        }
    }

    public string GetCurrTime()
    {
        string minStr;
        string secStr;

        minStr = SetTimeToString(min);

        secStr = SetTimeToString(sec);

        return minStr+":"+secStr;
    }

    public string SetTimeToString(float time)
    {
        //Si alguno es menor que 10 ponemos el 0 delante
        string strTime;
        if (time < 10)
        {
            strTime = "0" + time;
        }
        else
            strTime = time.ToString();

        return strTime;

    }

    public float GetSeconds()
    {
        return sec;
    }

   

}
