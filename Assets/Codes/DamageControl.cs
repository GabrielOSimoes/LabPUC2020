using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageControl : MonoBehaviour
{
    public int lifes = 3;
    public IAWalk iawalk;
    // Start is called before the first frame update

    public string gameObjectTag;
    void Start()
    {
        gameObjectTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage()
    {
        Debug.Log("Ativou o damage");
    }
    public void GetDamage()
    {
        iawalk.currentState = IAWalk.IaState.Dying;
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectiles"))
        {
            Debug.Log("Tomou dano e vida atual = " + lifes);

            lifes--;
            iawalk.currentState = IAWalk.IaState.Damage;
        }

        if (collision.collider.tag == "WeaponDropedEnemy")
        {
            Debug.Log("Tomou dano e vida atual = " + lifes);

            lifes--;
        }

        

        if (lifes < 0)
        {
            iawalk.currentState = IAWalk.IaState.Dying;
          
        }
       
    }
}
