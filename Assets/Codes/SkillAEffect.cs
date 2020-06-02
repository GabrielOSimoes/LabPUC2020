using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkillAEffect : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float skillDuration = 0.8f;
    public float shockWaveRadius = 4f;
    public float shockWaveSpeed = 7;
    public int explosionDamageInteger = 1;


    Vector3 currentExplosionPrefabScale;
    List<string> colliderNames;
    bool dontApplyDamageAgain = false;


    private void Start()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        Explode();
        colliderNames = new List<string>();
    }


    private void Update()
    {
        //gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(1, 1, 1) * Time.deltaTime * 10;
        //gameObject.GetComponent<BoxCollider>().size = gameObject.GetComponent<BoxCollider>().size + new Vector3(1f, 0, 1f) *10 * Time.deltaTime;
        if (gameObject.GetComponent<CapsuleCollider>().radius <= shockWaveRadius)
        {
            gameObject.GetComponent<CapsuleCollider>().radius = gameObject.GetComponent<CapsuleCollider>().radius + 0.5f + shockWaveSpeed * Time.deltaTime;
        }
       
        


    }
    void Explode()
    {

        GameObject explo = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 1.5f);
        Destroy(gameObject, 1.5f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {           

            foreach (string var in colliderNames)
            {
                if (var == collision.collider.gameObject.name)
                {
                    dontApplyDamageAgain = true; //se encontrar pelo menos 1 com o mesmo nome quer dizer que ja colidiu uma vez e portanto não irá aplicar dano novamente.
                }
            }

            if (collision.collider.gameObject.GetComponent<DamageControlEnemy>() != null && dontApplyDamageAgain == false)
            {
                for(int i =0; i < explosionDamageInteger; i++)
                {
                    collision.collider.gameObject.GetComponent<DamageControlEnemy>().DamageEnemy();
                }

                Debug.Log("Aplicou dano: ");
            }
        }

        colliderNames.Add(collision.collider.gameObject.name); //guarda o nome do objeto que colidiu pra n ocorrer mais de uma vez a aplicação de dano
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {

            if (collision.collider.gameObject.GetComponent<DamageControlEnemy>() != null)
            {
                Debug.Log("SAIU DA COLISAO: " + collision.collider.gameObject.name);
            }
        }
    }
}
