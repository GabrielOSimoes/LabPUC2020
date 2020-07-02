using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineSpawnPosition : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.SetShrineSpawnPoint(gameObject.transform.position);

            //if (backtoworld)
            //{
            //    StartCoroutine(MyLoadScene("MainScene"));
            //
            //}
            //else
            //{
            //    CommomStatus.lastPosition = other.transform.position-Vector3.forward*2;
            //    StartCoroutine(MyLoadScene(srinetoload));
            //}

        }

    }
}
