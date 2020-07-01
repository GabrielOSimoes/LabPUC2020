using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnPosition : MonoBehaviour
{
    [SerializeField] Vector3 shrinePosition;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameObject.transform.position = gameManager.GetCurrentSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
          gameObject.transform.position = gameManager.GetCurrentSpawnPoint(); 
      }

    }

}
