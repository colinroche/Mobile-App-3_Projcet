using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{ 
    private float rotateSpeed = 150.0f;
    [SerializeField] int coinValue = 0;
    [SerializeField] AudioClip coinSound;

    void Start()
    {
        Destroy(gameObject.GetComponent<BoxCollider>());
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(0.01f, 0.003f, 0.01f);
        bc.isTrigger = true;
    }

    void Update()
    {
        this.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<GameSession>().AddScore(coinValue);
        AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
