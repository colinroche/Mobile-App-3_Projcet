using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrackSpawner : MonoBehaviour
{
    ObjectSpawner objectSpawner;
    SpawnLevel spawnLevel;

    public List<GameObject> tracks;
    private Vector3 position;

    private float offset = 60.0f;

    private int coinStart = 0;
    private int trackCheck = 0;
    private int level = 1;

    private int coinsNum = 5;

    void Start()
    {
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
        }
    }

    private void LevelCheck() 
    {
        if (level == 3)
        {
            spawnLevel.FirstLevelSpawning();
            trackCheck = 0;
        }
        else if (level == 2)
        {
            spawnLevel.SecondLevelSpawning();
            trackCheck = 0;
        }
        else if (level == 1)
        {
            spawnLevel.ThirdLevelSpawning();
            trackCheck = 0;
        }
    }

   public void LevelChange()
   {
       level++;
   }
}
