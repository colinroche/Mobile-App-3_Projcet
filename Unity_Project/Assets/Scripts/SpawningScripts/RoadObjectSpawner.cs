using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectSpawner : MonoBehaviour
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
        trackStart = GameObject.Find("Track (0)").transform;
        trackEnd = GameObject.Find("Track (7)").transform;

        trackRamp = GameObject.Find("Track (6)").transform;
    }

    // Spawning objects random between left, middle and right tracks
    public void RandomSpawner(Transform transform)
    {
        position = new Vector3(0.0f, 0f, Random.Range(trackStart.position.z + (offset *2), 
                                     trackEnd.position.z + offset)); 
        Instantiate(transform, position, Quaternion.identity);
    }

    public void SetSpawner(Transform transform)
    {
        position = new Vector3(0f, 0f, trackRamp.position.z + offset); 
        Instantiate(transform, position, Quaternion.identity);
    }

    public void ArchwaySpawner()
    {
        Transform obstacleLeft;
        obstacleLeft = GameObject.Find("RoadObstacleLeft").transform;

        Transform obstacleMiddle;
        obstacleMiddle = GameObject.Find("RoadObstacleMiddle").transform;

        Transform obstacleRight;
        obstacleRight = GameObject.Find("RoadObstacleRight").transform;

        if (pickUpType % 3 == 0)
        {
            RandomSpawner(obstacleLeft);
            pickUpType++;
        }
        else if (pickUpType % 3 == 1)
        {
            RandomSpawner(obstacleMiddle);
            pickUpType++;
        }
        else
        {
            RandomSpawner(obstacleRight);
            pickUpType++;
        }
    }

    public void DamagedRoadSpawner()
    {
        Transform holeMiddle;
        holeMiddle = GameObject.Find("DamagedRoad Middle").transform;

        Transform holeSides;
        holeSides = GameObject.Find("DamagedRoad").transform;

        if (holeType % 2 == 0)
        {
            RandomSpawner(holeMiddle);
            holeType++;
        }
        else
        {
            RandomSpawner(holeSides);
            holeType++;
        }
    }

    public void RampSpawner()
    {
        Transform ramp;
        ramp = GameObject.Find("RampObject").transform;
        SetSpawner(ramp);
    }

    public void BridgeSpawner()
    {
        Transform bridge;
        bridge = GameObject.Find("Bridge").transform;
        SetSpawner(bridge);
    }
}
