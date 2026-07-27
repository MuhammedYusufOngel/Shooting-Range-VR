using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public TMP_Text scoreText;
    public TMP_Text bulletText;
    public TMP_Text timeText;
    public bool isCountdown = false;

    private int score;
    private int bullets;
    private float elapsedTime = 60;
    private bool isTimeRunning = false;
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Your score\n" + score.ToString();
    }

    public void AddBullet()
    {
        bullets++;
        bulletText.text = "Bullets\n" + bullets.ToString();
    }

    public bool GetCountdown()
    {
        return isCountdown;
    }

    public void StartCountdown()
    {
        isCountdown = true;
    }
    public void StopCountdown()
    {
        isCountdown = true;
    }

    public void StartTime()
    {
        isTimeRunning = true;
    }

    public void StopTime()
    {
        isTimeRunning = false;
    }

    private void Update()
    {
        if(isTimeRunning)
        {
            elapsedTime -= Time.deltaTime;

            if (elapsedTime <= 0)
                StopTime();

            else if (elapsedTime % 1 == 0)
                timeText.text = "Time\n" + elapsedTime.ToString();
        }

    }

}
