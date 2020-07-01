using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheGate : MonoBehaviour
{
    public GameObject gate;
    GameManager gameManager;
    public int ativaComQuantosKills = 0;
    bool openTheGate = false;
    private void Update()
    {
        if (openTheGate == true)
        {
            gate.transform.position += new Vector3(0, -0.0201f, 0);
        }
    }
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && gameManager.GetBossKilledCount() >= ativaComQuantosKills)
        {
            openTheGate = true;
            Debug.Log("colidiu com o portao");
        }
    }  
    
}
