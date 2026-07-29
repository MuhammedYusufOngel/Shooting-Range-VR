using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public TMP_Text scoreText;
    public TMP_Text bulletText;
    public TMP_Text timeText;
    public TMP_Text scoreBulletText;
    public bool isCountdown = false;
    public Transform wall;

    private int score;
    private static int maxScore = 10;
    private int bullets;
    private float elapsedTime = 30f;
    private bool isTimeRunning = false;
    private int isNextLevel = 0;
    private int level = 1;
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void AddScore()
    {
        score++;

        if(score - (maxScore * level) >= 0)
        {
            isNextLevel = 1;
            StopTime();
        }
        scoreText.text = "Your score\n" + score.ToString();
        string scorePerBullet = ((float)score / bullets).ToString("F2");
        scoreBulletText.text = "Score/Bullet\n" + scorePerBullet;
    }

    public void AddBullet()
    {
        bullets++;
        bulletText.text = "Bullets\n" + bullets.ToString();
        string scorePerBullet = ((float)score / bullets).ToString("F2");
        scoreBulletText.text = "Score/Bullet\n" + scorePerBullet;
    }

    public void LevelDesign()
    {
        Debug.Log("Level design initialized");

        if(isNextLevel == 1)
        {
            Debug.Log("Level design for next level");
            
            wall.position = new Vector3(wall.position.x, wall.position.y, wall.position.z - 5f);
        }
        else if(isNextLevel == -1)
        {
            Debug.Log("Level design for retry");

            wall.localPosition = new Vector3(-22f, 2.5f, 2f);
        }
    }

    public bool GetCountdown()
    {
        return isCountdown;
    }

    public void StartCountdown()
    {
        isCountdown = true;
        Debug.Log("Countdown started");
    }
    public void StopCountdown()
    {
        isCountdown = false;
        Debug.Log("Countdown stopped");
    }

    public void RestartGame()
    {
        isNextLevel = -1;
        StopTime();
        SetLevel(1);
        LevelDesign();
        SetIsNextLevel(0);
        StartCountdown();
        SetScore(0);
        SetBullets(0);
        Debug.Log("Game restarted");
    }

    public void StartTime()
    {
        isTimeRunning = true;
        Debug.Log("Time started");
    }

    public void StopTime()
    {
        isTimeRunning = false;
        timeText.text = "Time\n30";
        elapsedTime = 30f;
        Debug.Log("Time stopped");
    }

    public void SetLevel(int value)
    {
        level = value;
        Debug.Log("Level set to: " + level);
    }

    public int GetIsNextLevel()
    {
        return isNextLevel;
    }

    public void SetIsNextLevel(int value)
    {
        isNextLevel = value;
        Debug.Log("Next level set to: " + isNextLevel);
    }

    public bool GetIsTimeRunning()
    {
        return isTimeRunning;
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetScore(int value)
    {
        score = value;
        scoreText.text = "Your score\n" + score.ToString();
        Debug.Log("Score set to: " + score);
    }

    public void SetBullets(int value)
    {
        bullets = value;
        bulletText.text = "Bullets\n" + bullets.ToString();
        Debug.Log("Bullets set to: " + bullets);
    }

    public void Update()
    {
        if(isTimeRunning)
        {
            elapsedTime -= Time.deltaTime;

            if (elapsedTime <= 0)
            {
                StopTime();
                isNextLevel = -1;
            }

            timeText.text = "Time\n" + Mathf.Ceil(elapsedTime).ToString();
        }
    }

}
