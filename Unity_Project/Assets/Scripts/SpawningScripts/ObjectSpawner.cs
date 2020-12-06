using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private Vector3 position;

    private Transform trackStart;
    private Transform trackEnd;

    private float offset = 80.0f;

    private int pickUpType = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Getting start and end points to spawn objects on track
        trackStart = GameObject.Find("Track (1)").transform;
        trackEnd = GameObject.Find("Track (8)").transform;
    }

    // Spawning objects random between left, middle and right tracks
    public void Spawner(Transform transform, int numOfObjects)
    {
        int spawned = 0;
        while (spawned < numOfObjects)
        {
            if (spawned % 3 == 0)
            {
                position = new Vector3(-1.85f, 0f, Random.Range(trackStart.position.z + (offset *2), 
                                            trackEnd.position.z + offset));
            }
            else if (spawned % 3 == 1)
            {
                position = new Vector3(0.0f, 0f, Random.Range(trackStart.position.z + (offset *2), 
                                            trackEnd.position.z + offset));
            }
            else
            {
                position = new Vector3(1.85f, 0f, Random.Range(trackStart.position.z + (offset *2), 
                                            trackEnd.position.z + offset));
            }
            spawned++;
            Instantiate(transform, position, Quaternion.identity);
        } 
    }

    public void CoinSpawner()
    {
        Transform coins;
        int numCoins = 5;
        coins = GameObject.Find("Coins").transform;
        Spawner(coins, numCoins);
    }

    public void CarSpawner()
    {
        Transform cars;
        int numCars = 3;
        cars = GameObject.Find("Car").transform;
        Spawner(cars, numCars);
    }

    public void HeartSpawner()
    {
        Transform hearts;
        int numHearts = 1;
        hearts = GameObject.Find("Heart").transform;
        Spawner(hearts, numHearts);
    }

    // Insures that the same PowerUp is not spawned consecutively
    public void PowerUpSpawner()
    {
        int pickUpNum = 1;
        
        Transform shields;
        shields = GameObject.Find("Shield").transform;

        Transform coinMulti;
        coinMulti = GameObject.Find("Coins x2").transform;

        Transform boosts;
        boosts = GameObject.Find("Boost").transform;

        if (pickUpType % 3 == 0)
        {
            Spawner(shields, pickUpNum);
            pickUpType++;
        }
        else if (pickUpType % 3 == 1)
        {
            Spawner(coinMulti, pickUpNum);
            pickUpType++;
        }
        else
        {
            Spawner(boosts, pickUpNum);
            pickUpType++;
        }
    }
}
