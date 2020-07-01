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
        
    }

    public void SubscribeShrine(UnityEngine.Vector3 shrinePosition)
    {
        this.shrinePosition = shrinePosition;
        currentSpawnPoint = shrinePosition;
    }

    public void SubscribeSpawnPoint(UnityEngine.Vector3 currentSpawnPoint)
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

    public void SubscribeShrineNameToDestroy(string name)
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

        if(bossKilledCount == 2)
        {
            //open shrine 3
        }

        if(bossKilledCount == 3)
        {
            //open final gate
        }
    }

    public int GetBossKilledCount()
    {
        return bossKilledCount;
    }
}
