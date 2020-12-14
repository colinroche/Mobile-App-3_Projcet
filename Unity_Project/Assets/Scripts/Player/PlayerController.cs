using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] float xSpeed;
    [SerializeField] float zSpeed;
    [SerializeField] float oldZSpeed;
    [SerializeField] float mass;
    [SerializeField] Text powerUpText;

    float horizontalThrow;

    void Awake () 
    {
        DontDestroyOnLoad(transform.gameObject);
    }  
 
    // Start is called before the first frame update
    void Start()
    {
        StartPosition();  
    }

    public void EndSpeed()
    {
        oldZSpeed = zSpeed;
        zSpeed = 0;
    }

    public void StartSpeed()
    {
        zSpeed = oldZSpeed;
    }

    public void StartPosition()
    {
        transform.position = new Vector3(0, 0.5f, 0);
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
        zSpeed = zSpeed * 1.5f;
        powerUpText.text = "Boost";
        PlayerSpeed(zSpeed);
        yield return new WaitForSeconds(10);
        zSpeed = zSpeed / 1.5f;
        powerUpText.text = "";
        PlayerSpeed(zSpeed);
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

        if (other.tag == "SceneryChange")
        {
            FindObjectOfType<TrackSpawner>().SceneryChange();
        }  
    }

    public void PlayerSpeed(float speed)
    {
        zSpeed = speed;
        xSpeed = zSpeed / 10;
        mass = zSpeed / 2;
        GetComponent<Rigidbody>().mass = mass;
    }

    public void PlayerPosition()
    {
        transform.Translate(0f, 0f, 20f);
    }
}
