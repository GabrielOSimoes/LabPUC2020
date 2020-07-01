using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageControlEnemy : MonoBehaviour
{
    public int lifes = 3;
    public Animator anim;
    bool willDie = false;
    public string gameObjectTag;
    float timeDeadStart = 0;
    public float timeDeadEnd = 0;
    bool thisObjectCanBeDestroyed = false;

    void Start()
    {
        gameObjectTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {

        if(lifes <= 0 && !willDie)
        {
            SendMessage("WillDie");
            gameObject.GetComponent<EnemyAnimationController>().StopAllCoroutines();
            gameObject.GetComponent<EnemyAnimationController>().enabled = false; // o inimigo para de se manter na direção do player
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            
            willDie = true; // desativa todas as funções do player antes de tocar a animação de morte e destruir o gameobject
            anim.SetTrigger("Dead");

            
        }

        if (willDie)
        {
            timeDeadStart += Time.deltaTime;

            if (timeDeadStart >= timeDeadEnd)
            {
                Destroy(gameObject,10);

                if (gameObject.GetComponent<Boss>() != null)
                    gameObject.GetComponent<Boss>().WillDie();
            }
        }
        

    }

   public void DamageEnemy()
   {
        Debug.Log("Inimigo tomou dano: " + gameObject.name);
        lifes--;
    }
}
