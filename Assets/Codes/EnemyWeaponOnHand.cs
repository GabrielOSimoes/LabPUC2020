using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponOnHand : MonoBehaviour
{
    public GameObject weaponOnHand;
    public Transform handposition;
    // Start is called before the first frame update
    void Start()
    {
        weaponOnHand.transform.position = handposition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
