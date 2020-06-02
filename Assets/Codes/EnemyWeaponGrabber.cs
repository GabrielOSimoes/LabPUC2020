using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyWeaponGrabber : MonoBehaviour
{
    public GameObject weaponOnHand;
    public Transform handposition;

    private void Start()
    {        

       // weaponOnHand.transform.parent = handposition; //coloca como filho da mao
       // weaponOnHand.transform.localPosition = Vector3.zero;//vai pra posicao da mao
       // weaponOnHand.GetComponent<Rigidbody>().isKinematic = true;//desativa o rigidbody
       // weaponOnHand.transform.localRotation = Quaternion.identity;//reseta a rotacao
       // weaponOnHand.transform.gameObject.layer = transform.gameObject.layer;
    }

    private void Update()
    {
        //if (weaponOnHand)
        //{
        //    weaponOnHand.transform.parent = null;
        //    weaponOnHand.GetComponent<Rigidbody>().isKinematic = false;
        //    weaponOnHand.transform.Translate(-transform.up);
        //    weaponOnHand.layer = 0;
        //}

        weaponOnHand.transform.position = handposition.transform.position;
        weaponOnHand.transform.rotation = handposition.transform.rotation;
    }
}
