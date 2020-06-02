using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAWalkEnemyShadow : MonoBehaviour
{    
    public GameObject target;
    public Animator anim;
    AnimatorClipInfo[] m_CurrentClipInfo;
    public float desiredRotationSpeed = 2;
    public float closestPositionBeforeAttackingPlayer = 0.8f;    

    void Start()
    {
        m_CurrentClipInfo = this.anim.GetCurrentAnimatorClipInfo(0);

        for (int i = 0; i < m_CurrentClipInfo.Length; i++)
        {
            Debug.Log(m_CurrentClipInfo[i]);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        LockOnTheEnemy();
        MoveForward();;
    }

   

    void MoveForward()
    {
       if (Vector3.Distance(transform.position, target.transform.position) <= closestPositionBeforeAttackingPlayer)
       {
           anim.SetFloat("Velocity", 0);
           anim.SetTrigger("Attack");
       }
       else
       {
           anim.SetFloat("Velocity", 2.6f);
       }
    }

    void LockOnTheEnemy()
    {
        Vector3 relativePos = (target.transform.position - transform.position);

        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotationOnly_Y, desiredRotationSpeed);
    }

}
