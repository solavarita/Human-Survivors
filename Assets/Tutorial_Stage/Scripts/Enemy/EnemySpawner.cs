using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;
    [SerializeField] private float spawnDelayBetweenEnemies = 0.5f;

    private int currentWaveIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaveCoroutine());
    }

    private IEnumerator SpawnWaveCoroutine()
    {
        while (currentWaveIndex < waves.Length)
        {
            WaveData currentWave = waves[currentWaveIndex];
            foreach (var spawnInfo in currentWave.enemiesInWave)
            {
                for (int i = 0; i < spawnInfo.count; i++)
                {
                    GameObject enemy = EnemyPooling.Instance.SpawnEnemy(spawnInfo.enemyKey);
                    enemy.transform.position = GetRandomPositionOutsideCam();
                    yield return new WaitForSeconds(spawnDelayBetweenEnemies);
                }
            }

            // Đợi delay trước khi đến wave kế tiếp
            yield return new WaitForSeconds(currentWave.delayBeforeNextWave);
            currentWaveIndex++;
        }

        Debug.Log("All waves complete!");
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
