using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private GameObject player;
    private GameObject car;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        player = GameObject.Find("Player");
        player.GetComponent<Rigidbody>().useGravity = true;
    }

    public void QuitGame()
    {
        Debug.Log ("Quit");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Audio", volume);
    }

    public void PickBlue()
    {
        float speed = 50.0f;
        FindObjectOfType<PlayerController>().PlayerSpeed(speed);
    }
     public void PickGreen()
    {
        float speed = 60.0f;
        FindObjectOfType<PlayerController>().PlayerSpeed(speed);
    }
     public void PickRed()
    {
        float speed = 70.0f;
        FindObjectOfType<PlayerController>().PlayerSpeed(speed);
    }

    public void CarSpawn()
    {
        FindObjectOfType<PlayerController>().PlayerPosition();
    }
}
