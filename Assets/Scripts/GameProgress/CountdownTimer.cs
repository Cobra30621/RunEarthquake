using UnityEngine;

public class CountdownTimer 
{
    private float countdownTime; // 倒數計時的時間
    private bool isRunning = false; // 是否正在倒數計時

    public bool Finished => countdownTime <= 0;
 
    public void Update()
    {
        if (isRunning)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0)
            {
                countdownTime = 0;
                isRunning = false;
            }
        }
    }

    public void StartCountdown(float seconds)
    {
        if (!isRunning)
        {
            countdownTime = seconds;
            isRunning = true;
        }
    }

    public void PauseCountdown()
    {
        isRunning = false;
    }

    public void ResumeCountdown()
    {
        if (!isRunning && countdownTime > 0)
        {
            isRunning = true;
        }
    }

    public void StopCountdown()
    {
        isRunning = false;
        countdownTime = 0;
    }

    public float GetCurrentTime()
    {
        return countdownTime;
    }
}