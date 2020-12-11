using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrackSpawner : MonoBehaviour
{
    ObjectSpawner objectSpawner;
    SpawnLevel spawnLevel;

    public Material skybox1;
    public Material skybox2;
    public Material skybox3;

    public List<GameObject> tracks;
    private Vector3 position;

    private float offset = 60.0f;

    private GameObject[] scenery1;
    private GameObject[] scenery2;
    private GameObject[] scenery3;

    private int coinStart = 0;
    private int trackCheck = 0;
    private int level = 1;
    private int sceneryCheck = 1;

    private int coinsNum = 5;

    

    void Start()
    {
        RenderSettings.skybox = skybox1;
        CheckScenery();
        objectSpawner = GetComponent<ObjectSpawner>();
        spawnLevel = GetComponent<SpawnLevel>();
        
        // sorting order of tracks
        if (tracks != null && tracks.Count > 0)
        {
            tracks = tracks.OrderBy(t => t.transform.position.z).ToList();
        }
    }

   public void MoveTrack() 
   {
        Level();

        // Moves the current first part of the track to the last part of the track
        GameObject movedTrack = tracks[0];
        tracks.Remove(movedTrack);
        float newZValue = tracks[tracks.Count - 1].transform.position.z + offset;
        movedTrack.transform.position = new Vector3(0, 0, newZValue);
        tracks.Add(movedTrack);
   }

    private void Level()
    {
        // Initial coin spawn
        if (coinStart == 0)
        {
            objectSpawner.CoinSpawner(coinsNum);
            coinStart++;
        }

        // Only spawns objects once track has reset
        if (trackCheck < 8)
        {
            int index = tracks.IndexOf(tracks[trackCheck]);
            trackCheck++;
        }

        else
        {
            LevelCheck();
            CheckScenery();
        }
    }

    private void LevelCheck() 
    {
        if (level == 1)
        {
            spawnLevel.FirstLevelSpawning();
            trackCheck = 0;
        }
        else if (level == 2)
        {
            spawnLevel.SecondLevelSpawning();
            trackCheck = 0;
        }
        else if (level == 3)
        {
            spawnLevel.ThirdLevelSpawning();
            trackCheck = 0;
        }
        else {
            FindObjectOfType<GameSession>().ResetGameSession();
        }
    }

    private void CheckScenery()
    {
        if (sceneryCheck == 1)
        {
            RenderSettings.skybox = skybox1;
            scenery1 = GameObject.FindGameObjectsWithTag("Scenery1");
            foreach (GameObject scenery in scenery1)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(true);
              }
            }
            scenery2 = GameObject.FindGameObjectsWithTag("Scenery2");
            foreach (GameObject scenery in scenery2)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(false);
              }
            }
            scenery3 = GameObject.FindGameObjectsWithTag("Scenery3");
            foreach (GameObject scenery in scenery3)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(false);
              }
            }
        }
        else if (sceneryCheck == 2)
        {
            RenderSettings.skybox = skybox2;
            scenery1 = GameObject.FindGameObjectsWithTag("Scenery1");
            foreach (GameObject scenery in scenery1)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(false);
              }
            } 
            scenery2 = GameObject.FindGameObjectsWithTag("Scenery2");
            foreach (GameObject scenery in scenery2)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(true);
              }
            }
            scenery3 = GameObject.FindGameObjectsWithTag("Scenery3");
            foreach (GameObject scenery in scenery3)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(false);
              }
            }
        }
        else if (sceneryCheck == 3)
        {
            RenderSettings.skybox = skybox3;
            scenery1 = GameObject.FindGameObjectsWithTag("Scenery1");
            foreach (GameObject scenery in scenery1)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(false);
              }
            }
            scenery2 = GameObject.FindGameObjectsWithTag("Scenery2");
            foreach (GameObject scenery in scenery2)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(false);
              }
            }
            scenery3 = GameObject.FindGameObjectsWithTag("Scenery3");
            foreach (GameObject scenery in scenery3)
            {
              foreach (Transform s in scenery.transform) {
                  s.gameObject.SetActive(true);
              }
            }
        }
    }

   public void LevelChange()
   {
       level++;
   }

   public void SceneryChange()
   {
       sceneryCheck++;
   }
}
