using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueOPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject targetToLockOn;

    public float desiredRotationSpeed = 2;

    public float closestPositionBeforeAttackingPlayer = 0.8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThisObjectRotationEqualsTargetRotation();
        MoveForward();
        Vector3.MoveTowards(gameObject.transform.position, targetToLockOn.transform.position, 1f);
    }

    public void ThisObjectRotationEqualsTargetRotation()
    {

        Vector3 relativePos = (targetToLockOn.transform.position - transform.position);

        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotationOnly_Y, desiredRotationSpeed);

    }

    void MoveForward()
    {
        if (Vector3.Distance(transform.position, targetToLockOn.transform.position) <= closestPositionBeforeAttackingPlayer)
        {
           //ataca
        }
        else
        {
            Vector3.MoveTowards(gameObject.transform.position, targetToLockOn.transform.position, 5f);
        }
    }
}
