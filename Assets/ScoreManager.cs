using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    private PlayerController player;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public TextMeshProUGUI overScoreText;
    public TextMeshProUGUI overHighScoreText;

    public float score;
    public float highScore;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetFloat("highScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = player.getScore();
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
        }
        if(player.getHealth() <= 0)
        {
            overScoreText.text = "Score: " + score.ToString();
            overHighScoreText.text = "High Score: " + highScore.ToString();
            Destroy(gameObject);
        }
    }

    public void SaveHighScore()
    {
        if(score > highScore)
        {
            
        }
    }
}
