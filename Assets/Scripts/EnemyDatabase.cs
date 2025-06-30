using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour
{
    public EnemyData[] allEnemyData;

    private Dictionary<string, EnemyData> dataDict;

    private void Awake()
    {
        dataDict = new Dictionary<string, EnemyData>();
        foreach (var data in allEnemyData)
        {
            dataDict[data.enemyKey] = data;
        }
    }

    public EnemyData GetEnemyData(string key)
    {
        return dataDict.ContainsKey(key) ? dataDict[key] : null;
    }
}
