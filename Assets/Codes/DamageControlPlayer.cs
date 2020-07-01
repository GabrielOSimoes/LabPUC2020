using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageControlPlayer : MonoBehaviour
{
    GameManager gameManager;
    public TMPro.TextMeshProUGUI playerLifeText;
    public CanvasGroup healthBar;

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
            if(gameManager!=null)
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

        if (willDie)
        {
            lifes = 0;            
            playerLifeText.text = ("HP: " + lifes.ToString());
        }
        else
        {
            playerLifeText.text = ("HP: " + lifes.ToString());
            

        }

    }

    public void DamagePlayer()
    {
        lifes--;
        lifes = Mathf.Clamp(lifes, 0, 100);

        healthBar.alpha = (0.05f + (100f - (lifes)) / (100f));
        healthBar.alpha = Mathf.Clamp(healthBar.alpha, 0, 0.5f  ); 

    }

    public void HealPlayer()
    {
        lifes += 20;
        lifes = Mathf.Clamp(lifes, 0, 100);

        healthBar.alpha = ((100f - (lifes)) / (100f));
        healthBar.alpha = Mathf.Clamp(healthBar.alpha, 0, 0.5f);
    }
}
