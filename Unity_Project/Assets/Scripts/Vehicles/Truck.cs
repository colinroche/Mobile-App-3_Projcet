using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] AudioClip vehicleSound;

    void Start()
    {
        Destroy(gameObject.GetComponent<BoxCollider>());
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(0.08f, 0.035f, 0.025f);
        bc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        AudioSource.PlayClipAtPoint(vehicleSound, Camera.main.transform.position);
    }
}
