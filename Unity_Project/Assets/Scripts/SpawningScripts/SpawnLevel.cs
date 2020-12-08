using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    ObjectSpawner objectSpawner;
    RoadObjectSpawner roadObjectSpawner;
    
    private int numCoins = 0;
    private int numHearts = 0;
    private int numCars = 0;

    private int powerUpNum = 0;

    private int roadObjectCheck = 0;
    private int powerUpCheck = 0;

    void Start()
    {
        objectSpawner = GetComponent<ObjectSpawner>();
        roadObjectSpawner = GetComponent<RoadObjectSpawner>();
    }

    public void FirstLevelSpawning()
    {
        numCoins = 5;
        numHearts = 1;
        numCars = 1;
        powerUpNum = 1;
        if (roadObjectCheck != 4 || roadObjectCheck != 8)
        {
            objectSpawner.CoinSpawner(numCoins);
            objectSpawner.HeartSpawner(numHearts);
            objectSpawner.CarSpawner(numCars);

            if (powerUpCheck == 2)
            {
                objectSpawner.PowerUpSpawner(powerUpNum);
                powerUpCheck = 0;
            }
            roadObjectCheck++;
            powerUpCheck++;
        }
        if (roadObjectCheck == 4)
        {
            roadObjectSpawner.RampSpawner();
            roadObjectCheck++;
        }

        if (roadObjectCheck == 8)
        {
            roadObjectSpawner.BridgeSpawner();
            roadObjectCheck = -1;
        }
    }

    public void SecondLevelSpawning()
    {
        numCoins = 5;
        numHearts = 1;
        numCars = 1;
        powerUpNum = 1;
        if (roadObjectCheck != 4 || roadObjectCheck != 8)
        {
            objectSpawner.CoinSpawner(numCoins);
            objectSpawner.HeartSpawner(numHearts);
            objectSpawner.CarSpawner(numCars);

            //objectSpawner.BusSpawner(numCars);
            //objectSpawner.TruckSpawner(numCars);
            //roadObjectSpawner.ArchwaySpawner();
            //roadObjectSpawner.DamagedRoadSpawner();

            if (powerUpCheck == 2)
            {
                objectSpawner.PowerUpSpawner(powerUpNum);
                powerUpCheck = 0;
            }
            roadObjectCheck++;
            powerUpCheck++;
        }
        if (roadObjectCheck == 4)
        {
            roadObjectSpawner.RampSpawner();
            roadObjectCheck++;
        }

        if (roadObjectCheck == 8)
        {
            roadObjectSpawner.BridgeSpawner();
            roadObjectCheck = -1;
        }
    }

    public void ThirdLevelSpawning()
    {
        numCoins = 5;
        numHearts = 1;
        numCars = 1;
        powerUpNum = 1;
        if (roadObjectCheck != 4 || roadObjectCheck != 8)
        {
            objectSpawner.CoinSpawner(numCoins);
            objectSpawner.HeartSpawner(numHearts);
            objectSpawner.CarSpawner(numCars);

            //objectSpawner.BusSpawner(numCars);
            //objectSpawner.TruckSpawner(numCars);
            //roadObjectSpawner.ArchwaySpawner();
            //roadObjectSpawner.DamagedRoadSpawner();

            if (powerUpCheck == 2)
            {
                objectSpawner.PowerUpSpawner(powerUpNum);
                powerUpCheck = 0;
            }
            roadObjectCheck++;
            powerUpCheck++;
        }
        if (roadObjectCheck == 4)
        {
            roadObjectSpawner.RampSpawner();
            roadObjectCheck++;
        }

        if (roadObjectCheck == 8)
        {
            roadObjectSpawner.BridgeSpawner();
            roadObjectCheck = -1;
        }
    }
}
