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
            gameManager.SubscribeShrineNameToDestroy(gameObject.name);

            SceneManager.LoadScene(sceneToGoName);
        }           
        
       
    }
    
   IEnumerator MyLoadScene(string load)
   {
       //Camera.main.SendMessage("CallFadeOut");

       //se pá mete um canvas e usa o alpha group p dar o fade.
       //call fade out method
       yield return new WaitForSeconds(2);
       SceneManager.LoadScene(load);
   }

    private void FadeOut()
    {

    }

    private void FadeIn()
    {

    }
}
