using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ammoText;
    private int score = 0;
    public Text scoreText;
    public Text timerText;
    public float totalTime = 300f;
    private float currentTime;
    public bool isTimerFinished = false;

    private void Start()
    {
        score = PlayerPrefs.GetInt("PlayerScore");
        currentTime = totalTime;
        UpdateTimerText();
        StartCoroutine(StartTimer());
    }

    public void RestartTimer()
    {
        StartCoroutine(StartTimer());
    }
    public void UpdateAmmo(int ammoCount)
    {
        ammoText.text = "Bullets: " + ammoCount;
    }

    public void UpdateScoreText(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
    }

    private IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimerText();
        }
        if(currentTime == 0)
            TimerFinished();
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.RoundToInt(currentTime).ToString();
    }

    private void TimerFinished()
    {
        isTimerFinished = true;
    }
}
