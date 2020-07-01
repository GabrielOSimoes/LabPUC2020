using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawnPosition : MonoBehaviour
{
    [SerializeField] Vector3 shrinePosition;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            if (gameManager.GetBossKilledCount() > 0)
            {
                gameObject.transform.position = gameManager.GetCurrentSpawnPoint();
            }
        }
        
    }

    // Update is called once per frame
    
}
