using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    GameManager gameManager;    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            if(SceneManager.GetActiveScene().name == "Start")
            {
                LoadGame();
            }

            if(SceneManager.GetActiveScene().name == "Vitoria" || SceneManager.GetActiveScene().name == "GameOver")
            {
                LoadMenuInicial();
            }
        }
    }

    public void LoadMenuInicial()
    {
        ResetGameManager();
        SceneManager.LoadScene("Start");
    }

    public void LoadGame()
    {

        ResetGameManager();
        SceneManager.LoadScene("MinhaSceneTran2");
    }

    public void LoadVitoria()
    {
        ResetGameManager();
        SceneManager.LoadScene("Vitoria");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            LoadVitoria();
        }
    }

    private void ResetGameManager()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
            Destroy(gameManager.gameObject);
    }
}
