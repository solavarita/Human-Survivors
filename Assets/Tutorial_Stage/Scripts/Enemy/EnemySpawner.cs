using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] private WaveData[] waveDatas;
    
    public void SpawnEnemy()
    {
       
    }
}

//private Vector3 GetRandomPositionOutsideCam()
//{
//    Camera cam = Camera.main;
//    Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
//    Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

//    float buffer = 0.75f;
//    int side = Random.Range(0, 4);

//    switch (side)
//    {
//        case 0: return new Vector3(min.x - buffer, Random.Range(min.y, max.y), 0);
//        case 1: return new Vector3(max.x + buffer, Random.Range(min.y, max.y), 0);
//        case 2: return new Vector3(Random.Range(min.x, max.x), max.y + buffer, 0);
//        case 3: return new Vector3(Random.Range(min.x, max.x), min.y - buffer, 0);
//    }

//    return Vector3.zero;
//}