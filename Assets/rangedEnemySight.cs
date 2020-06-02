using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemySight : MonoBehaviour
{
    public GameObject rangedEnemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (rangedEnemy != null)
            {
                rangedEnemy.GetComponent<SpawnProjectileEnemy>().Shoot(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (rangedEnemy != null)
            {
                rangedEnemy.GetComponent<SpawnProjectileEnemy>().Shoot(false);
            }
        }
    }
}
