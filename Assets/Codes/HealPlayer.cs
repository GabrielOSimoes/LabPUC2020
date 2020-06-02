using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    bool playerLifeRecovered = false;
    float rotationSpeedLife = 90;
    private void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), rotationSpeedLife * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!playerLifeRecovered)
            {
                playerLifeRecovered = true;

                Debug.Log("Colidiu o cração");

                other.gameObject.SendMessage("HealPlayer", SendMessageOptions.DontRequireReceiver);

                rotationSpeedLife += rotationSpeedLife * 7;

                Destroy(gameObject, 3);
            }
        }
    }

}
