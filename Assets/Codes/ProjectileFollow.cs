using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour
{
    public GameObject playerCurrentPosition;
    GameObject targetPosition;
    bool projectileStop = false;
    public float projectileSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new GameObject();
        targetPosition.transform.position = playerCurrentPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!projectileStop)
        {
            LockOnTheEnemy();

            transform.position = Vector3.MoveTowards(transform.position, targetPosition.transform.position, projectileSpeed * Time.deltaTime);
        }
    }

    void LockOnTheEnemy()
    {
        Vector3 relativePos = (playerCurrentPosition.transform.position - transform.position);

        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotationOnly_Y, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Enemy")
        {
            projectileStop = true;

        }
    }
}
