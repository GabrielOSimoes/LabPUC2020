using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameManager gameManager;
    bool deathMessageReceived = false;
    public GameObject shrineDoor;

    private void Awake()
    {
        if (shrineDoor != null)
            shrineDoor.SetActive(false);

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
            if (shrineDoor != null)
                shrineDoor.SetActive(true);

            deathMessageReceived = true;
            gameManager.BossKilled();

            
        }
    }
}
