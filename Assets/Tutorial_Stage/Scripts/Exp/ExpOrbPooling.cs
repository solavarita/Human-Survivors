using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrbPooling : MonoBehaviour
{
    public static ExpOrbPooling Instance;

    [SerializeField] private GameObject expOrbPrefab;
    [SerializeField] private int poolSize = 100;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject orb = Instantiate(expOrbPrefab, transform);
            orb.SetActive(false);
            pool.Enqueue(orb);
        }
    }

    public GameObject SpawnExpOrb(Vector3 position)
    {
        GameObject orb;

        if (pool.Count > 0)
        {
            orb = pool.Dequeue();
        }
        else
        {
            orb = Instantiate(expOrbPrefab, transform);
        }

        orb.transform.position = position;
        orb.SetActive(true);

        return orb;
    }

    public void ReturnToPool(GameObject orb)
    {
        orb.SetActive(false);
        pool.Enqueue(orb);
    }
}
