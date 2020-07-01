using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorLuzPortao : MonoBehaviour
{
    GameManager gameManager;
    int bossKilledCount = 0;
    public int ativaComQuantosKills = 0;

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
        if (gameManager != null)
        {
            if(gameManager.GetBossKilledCount() >= ativaComQuantosKills)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
