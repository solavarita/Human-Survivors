using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public static EnemyPooling Instance;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int poolSize = 35;

    private Dictionary<string, Queue<GameObject>> poolDict = new Dictionary<string, Queue<GameObject>>();
    private Dictionary<string, GameObject> prefabLookup = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        foreach (GameObject prefab in enemyPrefabs)
        {
            string key = prefab.name;

            Queue<GameObject> poolQueue = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);

                // Gán key cho mỗi enemy khi tạo pool
                EnemyMovement enemy = obj.GetComponent<EnemyMovement>();
                if (enemy != null)
                {
                    enemy.originalPrefabKey = key;
                }

                poolQueue.Enqueue(obj);
            }

            poolDict[key] = poolQueue;
            prefabLookup[key] = prefab;
        }
    }

    public GameObject SpawnEnemy(string key)
    {
        if (!poolDict.ContainsKey(key))
        {
            Debug.LogWarning($"⚠️ Không tìm thấy pool cho key: {key}");
            return null;
        }

        GameObject obj;

        if (poolDict[key].Count > 0)
        {
            obj = poolDict[key].Dequeue();
        }
        else
        {
            obj = Instantiate(prefabLookup[key], transform);
        }

        obj.SetActive(true);

        // Gán key lại khi spawn (phòng trường hợp obj được tạo mới)
        EnemyMovement enemy = obj.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.originalPrefabKey = key;
        }

        return obj;
    }

    public void ReturnEnemyToPool(GameObject obj, string key)
    {
        if (!poolDict.ContainsKey(key))
        {
            Debug.LogWarning($"⚠️ Không tìm thấy pool để trả về: {key}");
            return;
        }

        obj.SetActive(false);
        poolDict[key].Enqueue(obj);
    }
}
