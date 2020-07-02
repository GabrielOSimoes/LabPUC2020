using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEngine.Vector3 shrinePosition;
    [SerializeField] UnityEngine.Vector3 currentSpawnPoint;
    [SerializeField] List<string> shrineNames;
    // Start is called before the first frame update

    [SerializeField] int playerHealth;

    public TMPro.TextMeshProUGUI QuestText;
    bool questUpdated = false;

    bool spawnedForTheFirstTime = false;

    bool openTheGates = false;
    [SerializeField] int bossKilledCount = 0;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(questUpdated == false)
        {
            questUpdated = true;
            if (bossKilledCount == 1)
            {
                QuestText.text = "Entre na próxima shrine e elimine o segundo demônio.";
            }
            else if (bossKilledCount == 2)
            {
                QuestText.text = "Entre na última shrine e elimine o demônio C'aa Piroto.";
            }
            else if (bossKilledCount == 3)
            {
                QuestText.text = "Explore a cidade e encontre a shrine divina.";
            }
        }
    }

    public void SetShrineSpawnPoint(UnityEngine.Vector3 shrinePosition)
    {
        this.shrinePosition = shrinePosition;
        currentSpawnPoint = shrinePosition;
    }

    public void SetSpawnPoint(UnityEngine.Vector3 currentSpawnPoint)
    {
        if(spawnedForTheFirstTime == false)
        {
            spawnedForTheFirstTime = true;
            this.currentSpawnPoint = currentSpawnPoint;
        }
        
    }

    public void GameOver()
    {
        shrinePosition = new UnityEngine.Vector3(0, 0, 0);
        currentSpawnPoint = shrinePosition;
        List<string> newShrineNamesList = new List<string>();
        shrineNames = newShrineNamesList;
    }

    public UnityEngine.Vector3 GetCurrentSpawnPoint()
    {
        return currentSpawnPoint;
    }

    public UnityEngine.Vector3 GetSpawnPoint()
    {
        return currentSpawnPoint;
    }

    public void SetShrineNameToDestroy(string name)
    {
        shrineNames.Add(name);
    }

    public List<string> GetShrineNameToDestroy()
    {
        return shrineNames;
    }

    public void BossKilled()
    {
        bossKilledCount+=1;
       
    }

    public int GetBossKilledCount()
    {
        return bossKilledCount;
    }

    public int GetPlayerHealth()
    {        
        return playerHealth;
    }

    public void SetPlayerHealth(int playerHealth)
    {
        this.playerHealth = playerHealth;
    }
}
