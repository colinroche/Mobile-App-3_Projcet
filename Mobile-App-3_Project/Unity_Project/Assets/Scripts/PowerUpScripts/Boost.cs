using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] AudioClip boostSound;

    void Start()
    {
        // Setting Boost Object's collider
        Destroy(gameObject.GetComponent<BoxCollider>());
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(3.0f, 0.5f, 3.0f);
        bc.isTrigger = true;
    }

    // When player collects boost, change player's speed
    private void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<PlayerController>().PlayerBoost();
        AudioSource.PlayClipAtPoint(boostSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
