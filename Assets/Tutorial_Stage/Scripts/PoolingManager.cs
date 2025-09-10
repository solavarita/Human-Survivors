using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;

    [System.Serializable]
    public class Pool
    {
        public string key;
        public GameObject prefab;
        public Transform parentObject;
        public int size;
    }

    [SerializeField] private List<Pool> pools;

    private Dictionary<string, Queue<GameObject>> poolDictionary;
    private Dictionary<string, Transform> parentDictionary;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        parentDictionary = new Dictionary<string, Transform>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            Transform poolParent = pool.parentObject;
            if (poolParent == null)
            {
                GameObject container = new GameObject(pool.key + "_Container");
                container.transform.SetParent(this.transform);
                poolParent = container.transform;
            }

            parentDictionary.Add(pool.key, poolParent);

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, poolParent);
                obj.SetActive(false);               
                objectPool.Enqueue(obj);
            }
        }
    }

    public GameObject SpawnFromPool(string key, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(key))
        {
            Debug.Log("Không tồn tại key");
            return null;
        }

        GameObject obj = poolDictionary[key].Dequeue();
        
        if (obj.activeInHierarchy)
        {
            obj = Instantiate(GetPrefabByKey(key), parentDictionary[key]);
        }

        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        poolDictionary[key].Enqueue(obj);

        return obj;
    }
    public void ReturnToPool(GameObject obj, string key)
    {
        obj.SetActive(false);
        obj.transform.SetParent(parentDictionary[key]);
    }

    private GameObject GetPrefabByKey(string key)
    {
        foreach (Pool pool in pools)
        {
            if (pool.key == key)
                return pool.prefab;
        }
        return null;
    }
}
