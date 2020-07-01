using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenuInicial()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MinhaSceneTran2");

        Debug.Log("Ué clicou no loadscene");
    }

    public void LoadVitoria()
    {
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
}
