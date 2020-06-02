using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    public GameObject target;
    Vector3 targetPositionXZ;
    public Animator anim;

    public NavMeshAgent agent;

    public float desiredRotationSpeed = 2;
    public float closestPositionBeforeAttackingPlayer = 0.8f;

    private bool attacking = false;
    public AnimationClip AttackingDamageClip; //Se colocar mais de uma animação de ataque será necessário criar uma matriz que contenha
    //todas as animações e o tempo de waitForSeconds na coroutine será tempo= anim1.lenght + anim2.lenght + anim3.lenght ...
    float attackingDamageClipLength;

    private bool takingDamage = false;
    private bool willDie = false;
    public AnimationClip TakingDamageClip;
    float takingDamageClipLength;

    private bool isRunning = false;
    public AnimationClip RunClip;
    public float runSpeed = 2.5f;
    float runClipLength;


    private void Start()
    {
        if (TakingDamageClip != null)
        {
            takingDamageClipLength = TakingDamageClip.length;
        }

        if (AttackingDamageClip != null)
        {
            attackingDamageClipLength = AttackingDamageClip.length;
        }

        if (RunClip != null)
        {
           runClipLength =RunClip.length;
        }

        targetPositionXZ = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        LockOnTheEnemy(); //mantem o inimigo olhando para o player o tempo inteiro

        if(attacking == false && takingDamage == false)
        {
            Run(); 

           //anim.SetFloat("Velocity", 2.5f);
           //agent.destination = target.transform.position;
        }

       if (Vector3.Distance(transform.position, target.transform.position) <= closestPositionBeforeAttackingPlayer && !attacking)
       {
           Attack();            
       }

    }

    void LockOnTheEnemy()
    {
        Vector3 relativePos = (target.transform.position - transform.position);

        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotationOnly_Y, desiredRotationSpeed);
    }

    #region METODOS DE CONTROLE DA ANIMAÇÃO DE ATAQUE
    void Attack()
    {
        attacking = true;
        //Trigger the animation here
        anim.SetFloat("Velocity", 0);
        anim.SetTrigger("Attack");
        //Trigger the start animation events here
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(attackingDamageClipLength + 0.5f);
        // trigger the stop animation events here
        attacking = false;
    }

    #endregion

    #region METODOS DE CONTROLE DA ANIMAÇÃO DE TAKE DAMAGE

    public void WillDie()
    {
        willDie = true;
    }
    public void DamageEnemy()
    {
        if (!willDie)
        {
            takingDamage = true;
            anim.SetTrigger("Damage");
            StartCoroutine(TakingDamage());
        }
        
    }

    IEnumerator TakingDamage()
    {
        yield return new WaitForSeconds(takingDamageClipLength);
        // trigger the stop animation events here
        takingDamage = false;
    }

    #endregion

    #region METODOS DE CONTROLE DA ANIMAÇÃO DE RUN

  void Run()
  {
      isRunning = true;
      anim.SetFloat("Velocity", 2.5f);
      StartCoroutine(Running());
     
  }
  
  IEnumerator Running()
  {
        agent.destination = target.transform.position;
      yield return new WaitForSeconds(runClipLength);
      // trigger the stop animation events here
      isRunning = false;
  }

    #endregion

    
}
