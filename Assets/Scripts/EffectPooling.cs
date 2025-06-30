using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPooling : MonoBehaviour
{
    public static EffectPooling Instance;

    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private int poolSize = 35;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(effectPrefab, this.transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public GameObject GetEffect()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {            
            GameObject obj = Instantiate(effectPrefab);
            return obj;
        }
    }
    public void ReturnEffect(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);        
    }
}
