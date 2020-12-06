﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    TrackSpawner trackSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        trackSpawner = GetComponent<TrackSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEnter()
    {
        trackSpawner.MoveTrack();
    }

}
