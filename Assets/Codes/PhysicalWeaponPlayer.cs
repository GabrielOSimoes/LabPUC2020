using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalWeaponPlayer : MonoBehaviour
{    private void OnCollisionEnter(Collision collision)
    {        

        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Bateu no inimigo: " + collision.collider.tag);

            collision.gameObject.SendMessage("DamageEnemy", SendMessageOptions.DontRequireReceiver);
        }
            
    }
}
