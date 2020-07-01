using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageControlPlayer : MonoBehaviour
{
    GameManager gameManager;

    public int lifes = 30;
    public Animator anim;
    bool willDie = false;
    public string gameObjectTag;
    float timeDeadStart = 0;
    public float timeDeadEnd = 0;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameObjectTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
     
      if (lifes <= 0 && !willDie)
      {
          SendMessage("WillDie");
          gameManager.GameOver();
          willDie = true; // desativa todas as funções do player antes de tocar a animação de morte e destruir o gameobject
          anim.SetTrigger("Dead");
            
            
        }
     
      if (willDie)
      {
          timeDeadStart += Time.deltaTime;
     
          if (timeDeadStart >= timeDeadEnd)
          {
              Destroy(gameObject);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("GameOver");
            }
      }
     

    }

    public void DamagePlayer()
    {
        lifes--;
        lifes = Mathf.Clamp(lifes, 0, 100);
    }

    public void HealPlayer()
    {
        lifes += 20;
        lifes = Mathf.Clamp(lifes, 0, 100);
    }

    void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 400, 30), "Player Life: " + lifes.ToString());
    }
}
