using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObstacleSpawner : MonoBehaviour
{
    private Vector3 position;

    private Transform trackStart;
    private Transform trackEnd;
    private Transform trackRamp;

    private float offset = 80.0f;

    private int pickUpType = 0;
    private int holeType = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Getting start and end points to spawn objects on track
        trackStart = GameObject.Find("Track (1)").transform;
        trackEnd = GameObject.Find("Track (8)").transform;

        trackRamp = GameObject.Find("Track (6)").transform;
    }

    // Spawning objects random between left, middle and right tracks
    public void Spawner(Transform transform, int numOfObjects)
    {
        int spawned = 0;
        while (spawned < numOfObjects)
        {
            position = new Vector3(0.0f, 0f, Random.Range(trackStart.position.z + (offset *2), 
                                     trackEnd.position.z + offset)); 
            spawned++;
            Instantiate(transform, position, Quaternion.identity);
        } 
    }

    public void ArchwaySpawner()
    {
        int numObstacle = 1;
        Transform obstacleLeft;
        obstacleLeft = GameObject.Find("RoadObstacleLeft").transform;

        Transform obstacleMiddle;
        obstacleMiddle = GameObject.Find("RoadObstacleMiddle").transform;

        Transform obstacleRight;
        obstacleRight = GameObject.Find("RoadObstacleRight").transform;

        if (pickUpType % 3 == 0)
        {
            Spawner(obstacleLeft, numObstacle);
            pickUpType++;
        }
        else if (pickUpType % 3 == 1)
        {
            Spawner(obstacleMiddle, numObstacle);
            pickUpType++;
        }
        else
        {
           Spawner(obstacleRight, numObstacle);
            pickUpType++;
        }
    }

    public void RampSpawner()
    {
        int spawnedRamp = 0;
        int numRamp = 1;
        Transform ramp;
        ramp = GameObject.Find("RampObject").transform;

        while (spawnedRamp < numRamp)
        {
            position = new Vector3(0f, 0f, trackRamp.position.z); 
            spawnedRamp++;
            Instantiate(ramp, position, Quaternion.identity);
        } 
    }

    public void DamagedRoadSpawner()
    {
        int numHole = 1;
        Transform holeMiddle;
        holeMiddle = GameObject.Find("DamagedRoad Middle").transform;

        Transform holeSides;
        holeSides = GameObject.Find("DamagedRoad").transform;

        if (holeType % 2 == 0)
        {
            Spawner(holeMiddle, numHole);
            holeType++;
        }
        else
        {
           Spawner(holeSides, numHole);
            holeType++;
        }
    }
}
