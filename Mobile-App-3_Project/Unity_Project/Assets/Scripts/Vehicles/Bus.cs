using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject.GetComponent<BoxCollider>());
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(0.09f, 0.024f, 0.022f);
        bc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        for (int i = 0; i < 2; i++)
        {
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
