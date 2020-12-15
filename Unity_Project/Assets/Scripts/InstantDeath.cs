using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        FindObjectOfType<GameSession>().PlayerDeath();
    }
}