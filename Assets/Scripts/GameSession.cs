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

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1)
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
      playerScore += addScoreValue;
      scoreText.text = playerScore.ToString();
   }

   public void ProcessPlayerDeath()
   {
      if(playerLives > 1)
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
       if(playerLives < 3)
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
      playerLives--;
      livesText.text = playerLives.ToString();
   }

   public void ResetGameSession()
   {
      SceneManager.LoadScene(0); // back to very start
      Destroy(gameObject);
   }

    // Updating distance travelled
    void Update()
    {
        int distance = Mathf.RoundToInt(player.transform.position.z);
        distanceText.text = distance.ToString() + "m";
    }
}
