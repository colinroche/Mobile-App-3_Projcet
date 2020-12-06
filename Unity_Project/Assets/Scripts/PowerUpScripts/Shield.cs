using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Setting Shield Object's collider
        Destroy(gameObject.GetComponent<BoxCollider>());
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.size = new Vector3(3.5f, 5.0f, 1.0f);
        bc.isTrigger = true;
    }

    // When player collects shield, disable lose of life
    private void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<GameSession>().ActivateShield();
        Destroy(gameObject);
    }
}
