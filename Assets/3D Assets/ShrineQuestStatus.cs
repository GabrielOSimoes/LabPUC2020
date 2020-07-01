using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineQuestStatus : MonoBehaviour
{
    [SerializeField] int BossKillCount;
    
    void Start()
    {
        BossKillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ABossWasKilled()
    {
        BossKillCount += 1;

        if (BossKillCount >= 3)
        {
            OpenTheGate();
        }
    }

    public void OpenTheGate()
    {

    }
}
