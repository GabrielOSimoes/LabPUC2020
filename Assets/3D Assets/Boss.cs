using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameManager gameManager;
    bool deathMessageReceived = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WillDie()
    {
        if(deathMessageReceived == false)
        {
            deathMessageReceived = true;
            gameManager.BossKilled();
        }
    }
}
