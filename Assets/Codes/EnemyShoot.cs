using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    public GameObject enemyTarget;

    public float timeToShoot = 10;

    private void Start()
    {
        
    }
    void Update()
    {
        //movimento de cabeca
        // float movx = Input.GetAxis("Mouse Y");
        // transform.Rotate(new Vector3(-movx, 0, 0));

        //inputs de teclado

        if (Input.GetKey(KeyCode.Alpha1)) indexWeapon = 0;
        if (Input.GetKey(KeyCode.Alpha2)) indexWeapon = 1;
        if (Input.GetKey(KeyCode.Alpha3)) indexWeapon = 2;
        if (Input.GetKey(KeyCode.Alpha4)) indexWeapon = 3;
        if (Input.GetKey(KeyCode.Alpha5)) indexWeapon = 4;
        if (Input.GetKey(KeyCode.Alpha6)) indexWeapon = 5;
        if (Input.GetKey(KeyCode.Alpha7)) indexWeapon = 6;
        if (Input.GetKey(KeyCode.Alpha8)) indexWeapon = 7;
        //se aperta tiro instancia o prefab

        timeToShoot -=Time.deltaTime;

        if (timeToShoot<=0)
        {
            timeToShoot = 5;
            //instancia o objeto e guarda a referencia
            GameObject myprojectile =
            Instantiate(projectilesPrefab[indexWeapon], transform.position,
            transform.rotation);

            if (myprojectile.GetComponent<guidedBomb>())
            {
                myprojectile.GetComponent<guidedBomb>().target = enemyTarget;
            }

            //adiciona uma forca no objeto
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 500);


        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            enemyTarget.transform.position = hit.point;
        }
        else
        {
            enemyTarget.transform.position = transform.position + transform.forward * 1000;
        }

    }
}
