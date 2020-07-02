using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwakeSpawnPoint : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.SetSpawnPoint(gameObject.transform.position);
    }

    void Start()
    {
        
        Destroy(gameObject,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
