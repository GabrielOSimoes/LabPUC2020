﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwakeSpawnPoint : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        gameManager.SubscribeSpawnPoint(gameObject.transform.position);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
