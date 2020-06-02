using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovements : MonoBehaviour
{
    public Vector3 plataformDirection;
    public float plataformSpeed = 3;
    bool playerLanded = false;
    // Start is called before the first frame update
    void Start()
    {
        plataformDirection = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {  

        transform.Translate( plataformDirection* plataformSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.collider.tag != "Player")
            {
                plataformDirection *= -1;
            }

            if (collision.collider.tag == "Player")
            {
                playerLanded = true;
                plataformDirection *= 0.5f;
            }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            plataformDirection *= -1;
            playerLanded = false;
        }
    }

}
