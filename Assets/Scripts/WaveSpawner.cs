using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]   
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawn;
    }

    [SerializeField] Wave[] waves;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] bool finishedSpawning;
    Wave currentWave;
    int currentWaveIndex;
    Transform playerTransform;

    public GameObject LevelupPanel;
    public GameObject VictoryPanel;

    // enemies spawned on a circle of this radius
    [SerializeField] private float spawnRadius = 15f;

    // get a random point on a circle with given radius
    private float3 RandomPointOnCircle(float radius)
    {
        Vector2 randomPoint = UnityEngine.Random.insideUnitCircle.normalized * radius;

        // return random point on circle, centered around the player position
        return new float3(randomPoint.x, randomPoint.y, -10f) + (float3)playerTransform.position;
    }

    void Start()
    {
        LevelupPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWaves(currentWaveIndex));
    }

    IEnumerator StartNextWaves(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        LevelupPanel.SetActive(false);
        StartCoroutine(SpawnWave(index));

    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for (int i = 0; i <= currentWaveIndex + 1; i++)
        {
            for (int j = 0; j < currentWave.count; j++)
            {
                if (playerTransform == null)
                {
                    yield break;
                }

                Enemy randomEnemy = currentWave.enemies[UnityEngine.Random.Range(0, currentWave.enemies.Length)];
                Vector3 spawnPoint = RandomPointOnCircle(spawnRadius);
                Instantiate(randomEnemy, spawnPoint, Quaternion.identity);

                yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
            }

            if (i == currentWaveIndex)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }


    void Update()
    {
        if (finishedSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length <= 15)
        {
            NextWaves();
        }

    }

    void NextWaves()
    {
        LevelupPanel.SetActive(true);
        finishedSpawning = false;

        if (currentWaveIndex + 1 < waves.Length)
        {
            currentWaveIndex++;
            StartCoroutine(StartNextWaves(currentWaveIndex));
        }

        else
        {
            Debug.Log("FinishedSpawning");
            LevelupPanel.SetActive(false);
            VictoryPanel.SetActive(true);

        }
    }

}
