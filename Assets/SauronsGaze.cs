using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauronsGaze : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LockOnTheEnemy();
    }

    void LockOnTheEnemy()
    {
        Vector3 relativePos = (player.transform.position - transform.position);

        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, /*LookAtRotationOnly_Y*/ LookAtRotation, 3);
    }
}
