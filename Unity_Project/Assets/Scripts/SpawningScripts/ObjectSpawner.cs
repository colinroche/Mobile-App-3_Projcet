using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] Transform parentItem;

    private Vector3 position;

    private Transform trackStart;
    private Transform trackEnd;

    private float offset = 80.0f;
    private int powerUpType = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Getting start and end points to spawn objects on track
        trackStart = GameObject.Find("Track (0)").transform;
        trackEnd = GameObject.Find("Track (7)").transform;
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
            Transform spawn = Instantiate(transform, position, Quaternion.identity);
            spawn.parent = parentItem;
            Destroy(spawn.gameObject, 10.0f);
        } 
    }

    public void CoinSpawner(int numCoins)
    {
        Transform coins;
        coins = GameObject.Find("Coins").transform;
        Spawner(coins, numCoins);
    }

    public void HeartSpawner(int numHearts)
    {
        Transform hearts;
        hearts = GameObject.Find("Heart").transform;
        Spawner(hearts, numHearts);
    }

    public void CarSpawner(int numCars)
    {
        Transform cars;
        cars = GameObject.Find("Car").transform;
        Spawner(cars, numCars);
    }

    public void BusSpawner(int numBuses)
    {
        Transform buses;
        buses = GameObject.Find("Bus").transform;
        Spawner(buses, numBuses);
    }

    public void TruckSpawner(int numTrucks)
    {
        Transform trucks;
        trucks = GameObject.Find("Truck").transform;
        Spawner(trucks, numTrucks);
    }

    // Insures that the same PowerUp is not spawned consecutively
    public void PowerUpSpawner(int powerUpNum)
    {
        Transform shields;
        shields = GameObject.Find("Shield").transform;

        Transform coinMulti;
        coinMulti = GameObject.Find("Coins x2").transform;

        Transform boosts;
        boosts = GameObject.Find("Boost").transform;

        if (powerUpType % 3 == 0)
        {
            Spawner(shields, powerUpNum);
            powerUpType++;
        }
        else if (powerUpType % 3 == 1)
        {
            Spawner(coinMulti, powerUpNum);
            powerUpType++;
        }
        else
        {
            Spawner(boosts, powerUpNum);
            powerUpType++;
        }
    }
}
