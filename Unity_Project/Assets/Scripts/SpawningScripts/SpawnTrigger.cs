using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public SpawnManager spawnManager;

    // Trigger used to move track
    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEnter();
    }
}
