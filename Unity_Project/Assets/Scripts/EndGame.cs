using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [Header("Player's Score")]
    [SerializeField] Text scoreText;
    private int playerScore = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Reset()
    {
        Destroy(gameObject);
        FindObjectOfType<GameSession>().ResetGameSession();
    }

    public void Restart()
    {
        //Destroy(gameObject);
        FindObjectOfType<GameSession>().RestartGameSession();
    }

    public void PlayerScore(int playerScore)
    {
        scoreText.text = playerScore.ToString();
    }
}
