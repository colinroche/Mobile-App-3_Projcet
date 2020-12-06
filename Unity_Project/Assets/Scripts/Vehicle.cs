using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject.GetComponent<BoxCollider>());
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(0.045f, 0.015f, 0.02f);
        bc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
}
