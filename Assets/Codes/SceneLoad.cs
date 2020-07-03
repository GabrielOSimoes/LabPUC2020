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
                StartCoroutine(LoadFirstLevel());
            }

            if(SceneManager.GetActiveScene().name == "Vitoria" || SceneManager.GetActiveScene().name == "GameOver")
            {
                StartCoroutine(LoadMainMenuIE());
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


    IEnumerator LoadMainMenuIE()
    {
        yield return new WaitForSeconds(1.5f);
        LoadMenuInicial();

    }

    IEnumerator LoadFirstLevel()
    {
        yield return new WaitForSeconds(1.0f);
        LoadGame();

    }
}
