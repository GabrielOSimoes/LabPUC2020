using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shrine : MonoBehaviour
{
    GameManager gameManager;
    public string sceneToGoName;
    public bool shrineToGoBack = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        List<string> shrineNamesToDestroy = gameManager.GetShrineNameToDestroy();
        foreach(string shrineName in shrineNamesToDestroy)
        {
            if(gameObject.name == shrineName)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(shrineToGoBack == false)
            gameManager.SetShrineNameToDestroy(gameObject.name);

            SceneManager.LoadScene(sceneToGoName);
        }        
        
       
    }    
   
}
