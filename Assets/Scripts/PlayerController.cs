using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] float xSpeed = 5.0f;
    [SerializeField] float zSpeed = 15.0f;

    float horizontalThrow;

    // Start is called before the first frame update
    void Start()
    {

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
        yield return new WaitForSeconds(10);
        zSpeed = zSpeed / 2;
    }

}
