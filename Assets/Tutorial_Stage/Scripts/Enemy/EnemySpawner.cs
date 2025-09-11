using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveData waveData;
    [SerializeField] private float waveStartTime = 0f; // thời điểm bắt đầu wave
    [SerializeField] private PoolingManager poolingManager; // drag sẵn trong Inspector

    private List<Coroutine> runningEvents = new List<Coroutine>();
    private Dictionary<WaveData.EnemySpawnEvent, int> aliveByEvent = new Dictionary<WaveData.EnemySpawnEvent, int>();

    private void Start()
    {
        StartCoroutine(HandleSpawnEvents());
    }

    private IEnumerator HandleSpawnEvents()
    {
        foreach (var spawnEvent in waveData.spawnEvents)
        {
            yield return new WaitUntil(() => Time.time >= waveStartTime + spawnEvent.startTime);
            Coroutine c = StartCoroutine(RunSpawnEvent(spawnEvent));
            runningEvents.Add(c);
        }
    }

    private IEnumerator RunSpawnEvent(WaveData.EnemySpawnEvent spawnEvent)
    {
        float endTime = waveStartTime + spawnEvent.endTime;
        int totalSpawned = 0;
        aliveByEvent[spawnEvent] = 0;

        while (Time.time < endTime)
        {
            // maxEnemy tổng số spawn
            if (spawnEvent.maxEnemy > 0 && totalSpawned >= spawnEvent.maxEnemy)
                break;

            // maxAlive (đang còn sống)
            if (spawnEvent.maxAlive > 0 && aliveByEvent[spawnEvent] >= spawnEvent.maxAlive)
            {
                yield return null;
                continue;
            }

            for (int i = 0; i < spawnEvent.spawnCount; i++)
            {
                if (spawnEvent.maxEnemy > 0 && totalSpawned >= spawnEvent.maxEnemy)
                    break;

                string key = spawnEvent.enemyKey[Random.Range(0, spawnEvent.enemyKey.Length)];
                Vector3 pos = GetRandomPositionOutsideCam();

                GameObject enemy = poolingManager.SpawnFromPool(key, pos, Quaternion.identity);
                if (enemy != null)
                {
                    totalSpawned++;
                    aliveByEvent[spawnEvent]++;
                }
            }

            yield return new WaitForSeconds(spawnEvent.spawnInterval);
        }
    }
    private Vector3 GetRandomPositionOutsideCam()
    {
        Camera cam = Camera.main;
        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float buffer = 0.75f;
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: return new Vector3(min.x - buffer, Random.Range(min.y, max.y), 0);
            case 1: return new Vector3(max.x + buffer, Random.Range(min.y, max.y), 0);
            case 2: return new Vector3(Random.Range(min.x, max.x), max.y + buffer, 0);
            case 3: return new Vector3(Random.Range(min.x, max.x), min.y - buffer, 0);
        }

        return Vector3.zero;
    }
}

