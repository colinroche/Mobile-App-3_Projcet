using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    private GameObject player;

    [Header("Distance Travelled")]
    [SerializeField] int playerDistance = 0;
    [SerializeField] Text distanceText;

    [Header("Player's Score")]
    [SerializeField] int playerScore = 0;
    [SerializeField] Text scoreText;

    [Header("Player's Lives")]
    [SerializeField] int playerLives = 3;
    [SerializeField] Text livesText;

    [Header("Player's PowerUp")]
    [SerializeField] Text powerUpText;

    private bool playerDeath = true;
    private bool doubleScore = false;

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // Setting up starting values for player
        player = GameObject.Find("Player");
        distanceText.text = playerDistance.ToString() + "m";
        scoreText.text = playerScore.ToString();
        livesText.text = playerLives.ToString();
    }

    public void AddScore(int addScoreValue)
    {
        if (doubleScore == true)
        {
            playerScore += addScoreValue;
        }
        playerScore += addScoreValue;
        scoreText.text = playerScore.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession(); // send back to Main Menu
        }
    }

    public void ProcessPlayerLives()
    {
        if (playerLives < 3)
        {
            AddLife();
        }
    }

    private void AddLife()
    { 
        playerLives++;
        livesText.text = playerLives.ToString();
    }

    private void TakeLife() 
    {
        if (playerDeath == true)
        {
            playerLives--;
            livesText.text = playerLives.ToString();
        }
    }

    public void ResetGameSession()
    {
        if (playerDeath == true)
        {
            player = GameObject.Find("Player");
            Destroy(player);
            Destroy(gameObject);
            SceneManager.LoadScene(0); // back to very start
            
        }
    }

    public void ActivateShield()
    {
        StartCoroutine (SetPlayerDeath());
    }

    // Deactivatet the player's ability to die for 10 seconds
    IEnumerator SetPlayerDeath()
    {
        playerDeath = false;
        powerUpText.text = "Shield";
        yield return new WaitForSeconds(10);
        playerDeath = true;
        powerUpText.text = "";
    }

    public void CoinMultiply()
    {
        StartCoroutine (SetCoinMulitplier());
    }

    // Double coin value is set to true for 10 seconds
    IEnumerator SetCoinMulitplier()
    {
        doubleScore = true;
        powerUpText.text = "Coin x2";
        yield return new WaitForSeconds(10);
        doubleScore = false;
        powerUpText.text = "";
    }

    // Updating distance travelled
    void Update()
    {
        int distance = Mathf.RoundToInt(player.transform.position.z);
        distanceText.text = distance.ToString() + "m";
    }
}
