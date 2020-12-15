using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [Header("HighScore")]
    [SerializeField] Text highScoreText;

    private int highScore;
    private int scene;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void HighScoreCheck(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
           PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", highScore);    
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();    
    }
}
