using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    ObjectSpawner objectSpawner;
    RoadObjectSpawner roadObjectSpawner;
    
    private int numCoins = 0;
    private int numHearts = 0;
    private int numVehicle = 0;

    private int powerUpNum = 0;

    private int roadObjectCheck = 0;
    private int powerUpCheck = 0;
    private int archwayCheck = 0;
    private int damagedCheck = 0;

    void Start()
    {
        objectSpawner = GetComponent<ObjectSpawner>();
        roadObjectSpawner = GetComponent<RoadObjectSpawner>();
    }

    public void FirstLevelSpawning()
    {
        numCoins = 5;
        numHearts = 1;
        numVehicle = 2;
        powerUpNum = 1;

        if (roadObjectCheck != 4 || roadObjectCheck != 8)
        {
            objectSpawner.CoinSpawner(numCoins);
            objectSpawner.HeartSpawner(numHearts);
            objectSpawner.CarSpawner(numVehicle);

            if (archwayCheck == 2)
            {
                roadObjectSpawner.ArchwaySpawner();
                archwayCheck = 0;
            }

            if (powerUpCheck == 2)
            {
                objectSpawner.PowerUpSpawner(powerUpNum);
                powerUpCheck = 0;
            }
            roadObjectCheck++;
            archwayCheck++;
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
        numCoins = 8;
        numHearts = 1;
        numVehicle = 2;
        powerUpNum = 1;
        if (roadObjectCheck != 4 || roadObjectCheck != 8)
        {
            objectSpawner.CoinSpawner(numCoins);
            objectSpawner.HeartSpawner(numHearts);
            objectSpawner.CarSpawner(numVehicle);
            objectSpawner.BusSpawner(numVehicle);

            if (archwayCheck == 2)
            {
                roadObjectSpawner.ArchwaySpawner();
                archwayCheck = 0;
            }

            if (powerUpCheck == 1)
            {
                objectSpawner.PowerUpSpawner(powerUpNum);
                powerUpCheck = 0;
            }
            roadObjectCheck++;
            damagedCheck++;
            archwayCheck++;
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
        numCoins = 10;
        numHearts = 1;
        numVehicle = 1;
        powerUpNum = 1;
        if (roadObjectCheck != 4 || roadObjectCheck != 8)
        {
            objectSpawner.CoinSpawner(numCoins);
            objectSpawner.HeartSpawner(numHearts);
            objectSpawner.CarSpawner(numVehicle);
            objectSpawner.BusSpawner(numVehicle);
            objectSpawner.TruckSpawner(numVehicle);

            if (damagedCheck == 2)
            {
                print("DDADADF");
                roadObjectSpawner.DamagedRoadSpawner();
                damagedCheck = 0;
            }
           if (archwayCheck == 2)
            {
                roadObjectSpawner.ArchwaySpawner();
                archwayCheck = 0;
            }

            if (powerUpCheck == 1)
            {
                objectSpawner.PowerUpSpawner(powerUpNum);
                powerUpCheck = 0;
            }
            roadObjectCheck++;
            damagedCheck++;
            powerUpCheck++;
            archwayCheck++;
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
