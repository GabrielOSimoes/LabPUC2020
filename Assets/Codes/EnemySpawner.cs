using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool SpawnEnemies = false;
    public List<GameObject> spawnable;
    bool IsSpawning = false;
    int enemiesCount = 0;

    void Start()
    {

        foreach (var enemy in spawnable) //AQUI VAI INSTANCIAR DEPOIS, NO MOMENTO VAMOS SÓ ATIVAR e desativas O OBJETO para testar o spawner
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!IsSpawning && other.tag == "Player")
        {
            IsSpawning = true;

            foreach (var enemy in spawnable) //AQUI VAI INSTANCIAR DEPOIS, NO MOMENTO VAMOS SÓ ATIVAR O OBJETO
            {
                enemy.SetActive(true);
                enemy.transform.parent = null;
            }

            Destroy(gameObject);
        }

    }
}
