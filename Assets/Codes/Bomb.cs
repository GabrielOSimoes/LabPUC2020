using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombForce=1000;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //chama uma funcao depois de 3 seg
        //Invoke("Explode", 3);
    }
    void Explode()
    {

       GameObject explo= Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 4);
       //Destroi o objeto
        Destroy(gameObject);
        //array de raycasts
        RaycastHit[] hits;

        hits=Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

       // if (hits.Length > 0)
       // {
       //     foreach(RaycastHit hit in hits)
       //     {
       //         if (hit.rigidbody)
       //         {
       //             hit.rigidbody.isKinematic = false;
       //             hit.rigidbody.AddExplosionForce(bombForce, transform.position, 5);
       //             //hit.collider.gameObject.SendMessage("GetDamage",SendMessageOptions.DontRequireReceiver);
       //         }
       //     }
       // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "Projectile")
        {
            collision.collider.SendMessage("DamagePlayer", SendMessageOptions.DontRequireReceiver);
            Explode();

        }

        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Projectile")
        {
            collision.collider.SendMessage("DamageEnemy", SendMessageOptions.DontRequireReceiver);
            Explode();

        }

    }

}
