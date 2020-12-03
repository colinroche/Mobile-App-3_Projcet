using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrackSpawner : MonoBehaviour
{
    ObjectSpawner objectSpawner;
    public List<GameObject> tracks;
    private Vector3 position;

    private float offset = 80.0f;
    private int trackCheck = 0;
    private int powerUpCheck = 0;

    void Start()
    {
        objectSpawner = GetComponent<ObjectSpawner>();
        // sorting order of tracks
        if (tracks != null && tracks.Count > 0)
        {
            tracks = tracks.OrderBy(t => t.transform.position.z).ToList();
        }
    }

   public void MoveTrack() 
   {
       // Initial coin spawn
        if (trackCheck == 0)
        {
            objectSpawner.CoinSpawner();
        }
        // Only spawns objects once track has reset
        if (trackCheck <= 8)
        {
            int index = tracks.IndexOf(tracks[trackCheck]);
            trackCheck++;
        }
        else
        {
            objectSpawner.CoinSpawner();
            objectSpawner.CarSpawner();
            objectSpawner.HeartSpawner();

            trackCheck = 1;
            powerUpCheck++;
        }

        if (powerUpCheck == 2)
        {
            objectSpawner.PowerUpSpawner();
            powerUpCheck = 0;
        }

        // Moves the current first part of the track to the last part of the track
        GameObject movedTrack = tracks[0];
        tracks.Remove(movedTrack);
        float newZValue = tracks[tracks.Count - 1].transform.position.z + offset;
        movedTrack.transform.position = new Vector3(0, 0, newZValue);
        tracks.Add(movedTrack);
   }
}
