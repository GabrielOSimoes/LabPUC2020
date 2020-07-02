using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnPosition : MonoBehaviour
{
    [SerializeField] Vector3 shrinePosition;
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {  
        if(SceneManager.GetActiveScene().name == "MinhaSceneTran2")
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
