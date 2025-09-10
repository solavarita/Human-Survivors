using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [SerializeField] private WaveData waveData;
    [SerializeField] private EnemyData[] enemyDatas;
    [SerializeField] private Text gameTimeText;

    private Dictionary<string, EnemyData> enemyDataDict;

    private float gameTime;
    private int currentEventIndex;
    private int lastSecond = -1;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        enemyDataDict = new Dictionary<string, EnemyData>();
        foreach (var data in enemyDatas)
        {
            if (!enemyDataDict.ContainsKey(data.enemyKey))
            {
                enemyDataDict.Add(data.enemyKey, data);
            }
        }
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        int currentSecs = Mathf.FloorToInt(gameTime);
        if(currentSecs != lastSecond)
        {
            System.TimeSpan t = System.TimeSpan.FromSeconds(currentSecs);
            gameTimeText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            lastSecond = currentSecs;
        }           

        CheckEvents();
    }

    private void CheckEvents()
    {
        if (waveData == null || waveData.spawnEvents.Length == 0)
            return;
        if (currentEventIndex >= waveData.spawnEvents.Length)
            return;

        var evt = waveData.spawnEvents[currentEventIndex];

        if (gameTime > evt.endTime)
        {
            currentEventIndex++;
            return;
        }

        if(gameTime >= evt.startTime && gameTime <= evt.endTime)
        {
           //Do something
        } 
    }

}
