using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public TMP_Text scoreText;
    public TMP_Text bulletText;
    private int score;
    private int bullets;
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void AddBullet()
    {
        bullets++;
        bulletText.text = bullets.ToString();
    }
}
