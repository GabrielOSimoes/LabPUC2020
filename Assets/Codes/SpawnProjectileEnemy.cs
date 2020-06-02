using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnProjectileEnemy : MonoBehaviour
{
    public GameObject target;
    public GameObject projectileSpawnPoint;
    public GameObject projectile;
    public float timeBetweenShots = 5;
    float timeToShootAux;

    bool shootTarget = false;

    private void Start()
    {
        timeToShootAux = timeBetweenShots;
    }
    void Update()
    {       

        if (shootTarget == true)
        {
            LockOnTheEnemy();

            timeBetweenShots -= Time.deltaTime;
            if (timeBetweenShots <= 0)
            {
                timeBetweenShots = timeToShootAux;
                GameObject myprojectile = Instantiate(projectile, projectileSpawnPoint.transform.position,
                transform.rotation);

                myprojectile.SetActive(true);
            }
        }
        
    }

    void LockOnTheEnemy()
    {
        Vector3 relativePos = (target.transform.position - transform.position);

        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotationOnly_Y, 3);
    }

    public void Shoot(bool shouldShoot)
    {
        shootTarget = shouldShoot;
    }
   

}
