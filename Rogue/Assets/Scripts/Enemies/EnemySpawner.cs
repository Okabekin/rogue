using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; //Liste der Gruppen von Gegnern die diese Welle spawnen
        public int waveQuota; //Anzahl aller zu spawnenden Gegner dieser Welle
        public float spawnInterval; //Intervall zwischen der zu spawnenden Gegnern
        public int spawnCount; //Anzahl an bereits gespawnter Gegner eines Types
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount; //Anzahl der zu spanenden Gegnertypen dieser Welle 
        public int spawnCount; //Anzahl an bereits gespawnter Gegner eines Types
        public GameObject enemyPrefab;
    }

    public List<Wave> waves; //Liste aller Wellen eines Spiels
    public int currentWaveCount;  //Index der aktuellen Welle, startet bei 0

    [Header("Spawner Attributes")]
    float spawnTimer; //Time until next enemy spawns
    public int enemiesAlive; //Nr of enemies alive
    public int maxEnemiesAllowed; //Nr of Enemies allowed
    public bool maxEnemiesReached; //Check, if the max enemies has been reached
    public float waveInterval; //Time between waves

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints; //Spawn points of enemies

    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    // Update is called once per frame
    void Update()
    {
        //Check, if the wave has ended to start the next wave
        if(currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;

        //Check when to spawn the next enemy
        if(spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }
    IEnumerator BeginNextWave()
    {
        //Waves function
        yield return new WaitForSeconds(waveInterval); 

        if(currentWaveCount< waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    //Cap the maximum enemies allowed on the map, aswell as spawning enemies only in the current wave
    void SpawnEnemies()
    {
        //Check, ob die Mindestanzahl an Gegnern in einer Welle bereits gespawnt wurde
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            //Weiterspawnen, wenn dies nicht der Fall ist
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                //Check, ob die Mindestanzahl eines bestimmenten Gegnerntyps in einer Welle bereits gespawnt wurde
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    //Limits the Nr of enemies on the map
                    if(enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    //Spawn enemies at random spawn points
                    Instantiate(enemyGroup.enemyPrefab, Player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }
        if(enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }
    public void OnEmeyKilled()
    {
        enemiesAlive--;
    }
        
}