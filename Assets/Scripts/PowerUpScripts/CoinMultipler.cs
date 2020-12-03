using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMultipler : MonoBehaviour
{
    void Start()
    {
        // Setting box collider on multiplier object
        Destroy(gameObject.GetComponent<BoxCollider>());
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(2.5f, 2.5f, 2.5f);
        bc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<Coin>().CoinMultiply();
        Destroy(gameObject);
    }
}
