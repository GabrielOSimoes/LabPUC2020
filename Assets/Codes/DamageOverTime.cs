using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Explode(GameObject target)
    {

        GameObject explo = Instantiate(explosionPrefab, target.transform.position, transform.rotation);
        Destroy(explo, 5);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.collider.tag == "Player")
        {
            Explode(collision.collider.gameObject);

            Debug.Log(collision.collider.tag);

            collision.gameObject.SendMessage("DamagePlayer", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Enemy")
        {
            Debug.Log("bateu no player");

            Debug.Log(collision.collider.tag);

            collision.gameObject.SendMessage("DamagePlayer", SendMessageOptions.DontRequireReceiver);

            collision.gameObject.SendMessage("DamageEnemy", SendMessageOptions.DontRequireReceiver);
        }
    }
}
