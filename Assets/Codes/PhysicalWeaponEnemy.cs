using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalWeaponEnemy : MonoBehaviour
{
    bool canHit = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && canHit == true)
        {
            canHit = false;

            Debug.Log("bateu no player");

            Debug.Log(collision.collider.tag);

            collision.gameObject.SendMessage("DamagePlayer", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            canHit = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        canHit = false;
    }
}
