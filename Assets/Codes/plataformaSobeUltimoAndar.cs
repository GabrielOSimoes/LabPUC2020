using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaSobeUltimoAndar : MonoBehaviour
{
    public GameObject target;
    bool podeSubir;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (podeSubir == true)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position, 5 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        podeSubir = true;
    }
}
