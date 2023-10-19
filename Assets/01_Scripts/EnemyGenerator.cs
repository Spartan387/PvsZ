using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    [Space]
    public int numEnemyWave;
    public float frecuencyEnemyWave;
    [Space]
    public int numWaves;
    public float frecuencyWaves;

    int countWave = 0;
    int countWaves = 0;
    bool waveStarted;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("CreateEnemy", 2.0f);
        CreateWaves();
    }
    void FixedUpdate()
    {
        if (!waveStarted) 
        {
            if (countWaves < numWaves)
            {
                waveStarted = true;
                Invoke("CreateWaves", frecuencyWaves);
            }
        }
        else 
        {
            countWaves = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateEnemy()
    {
        GameObject enemyTemp = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

    }

    void CallWave()
    {
        CreateWave(numEnemyWave, frecuencyEnemyWave);
    }
    void CreateWave(int numEnemy, float frecuency)
    {
        CreateEnemy();
        countWave++;
        if (countWave < numEnemy)
        {
            waveStarted = true;
            Invoke("CallWave", frecuency);
        }
        else
        {
            CancelInvoke("CallWave");
            countWave = 0;
            waveStarted = false;
        }
    }
    
    void CreateWaves() 
    {
        CreateWave(numEnemyWave, frecuencyEnemyWave);
        countWaves++;

    }
}
