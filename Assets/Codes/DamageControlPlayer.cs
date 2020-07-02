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
    public float timeToRegen = 1;
    float regenCooldown = 0;

    public int lifes = 30;
    public Animator anim;
    bool willDie = false;
    public string gameObjectTag;
    float timeDeadStart = 0;
    public float timeDeadEnd = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameManager = FindObjectOfType<GameManager>();   
        if(gameManager.GetPlayerHealth() > 0)
        {
            lifes = gameManager.GetPlayerHealth();
            lifes = Mathf.Clamp(lifes, 0, 100);
            healthBar.alpha = (0.05f + (100f - (lifes)) / (100f));
            healthBar.alpha = Mathf.Clamp(healthBar.alpha, 0, 0.5f);
        }
        

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

        if(lifes < 100)
        lifeRegen();

    }

    public void DamagePlayer()
    {
        lifes--;
        lifes = Mathf.Clamp(lifes, 0, 100);

        gameManager.SetPlayerHealth(lifes);
        healthBar.alpha = (0.05f + (100f - (lifes)) / (100f));
        healthBar.alpha = Mathf.Clamp(healthBar.alpha, 0, 0.35f  ); 

    }

    public void HealPlayer()
    {
        lifes += 20;
        lifes = Mathf.Clamp(lifes, 0, 100);

        if(gameManager!=null)
        gameManager.SetPlayerHealth(lifes);

        healthBar.alpha = ((100f - (lifes)) / (100f));
        healthBar.alpha = Mathf.Clamp(healthBar.alpha, 0, 0.35f);
    }

    private void lifeRegen()
    {
        regenCooldown += Time.deltaTime;

        if(regenCooldown > timeToRegen)
        {
            regenCooldown = 0;
            lifes += 1;
            gameManager.SetPlayerHealth(lifes);

            healthBar.alpha = ((100f - (lifes)) / (100f));
            healthBar.alpha = Mathf.Clamp(healthBar.alpha, 0, 0.35f);
        }
    }
}
