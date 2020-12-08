using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] float xSpeed = 5.0f;
    [SerializeField] float zSpeed = 40.0f;
    [SerializeField] float mass;
    [SerializeField] Text powerUpText;

    float horizontalThrow;
    

    // Start is called before the first frame update
    void Start()
    {
        mass = zSpeed / 2;
        GetComponent<Rigidbody>().mass = mass;
    }

    // Update is called once per frame
    void Update()
    {
        // Setting player side movement
        horizontalThrow = Input.GetAxis("Horizontal");
        float xOffset = horizontalThrow * xSpeed;

        // new position
        transform.Translate(new Vector3(xOffset, 0, 0) * Time.deltaTime);
        // Player moves constantly forward by zSpeed
        transform.Translate(Vector3.forward * Time.deltaTime * zSpeed);
    }

    public void PlayerBoost()
    {
        StartCoroutine (ProcessPlayerBoost());
    }

    // Double the player's speed for ten seconds
    IEnumerator ProcessPlayerBoost()
    {
        zSpeed = zSpeed * 2;
        powerUpText.text = "Boost";
        yield return new WaitForSeconds(10);
        zSpeed = zSpeed / 2;
        powerUpText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Track")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (other.tag == "Top")
        {
            transform.rotation = Quaternion.Euler(-10, 0, 0);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
            transform.Translate(Vector3.down * Time.deltaTime * zSpeed);
        }

        if (other.tag == "LevelChange")
        {
            FindObjectOfType<TrackSpawner>().LevelChange();
        }    
    }
}
