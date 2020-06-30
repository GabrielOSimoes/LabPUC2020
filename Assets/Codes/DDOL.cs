using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{

    public GameObject[] ShrineDoorLocations;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //pega o nome do da shrine, spawn point etc e da spawn no player no local marcado aqui.
            //então por exemplo, desde o iniciio do gameplay na scene 01 a gente pega o spawn point e guarda no ddol.
            //carrega a segunda scene e o spawn point ja vai ser na frente do krl da shrine correspondente.
            //mata o boss e entra na shrine de novo.
            //dessa vez vou ter numa variável SHRINE LOCATION ENTERED o novo spawn point do player.
            //então a gente joga a localização do player spawn point nessa variável
            
        //TALVEZ o ddol deva ser aplicado no player tb. Daí coloca num onload pra o player spawnar no ponto desejado JA ESTANDO COM A ARMA EM MÃOS.
        }
    }
}
