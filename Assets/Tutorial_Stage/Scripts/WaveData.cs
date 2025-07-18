using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveData", menuName = "Enemy/Wave Data")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class EnemySpawnInfo
    {
        public string enemyKey;       // key của prefab (tên)
        public int count;             // số lượng spawn
    }

    public EnemySpawnInfo[] enemiesInWave;
    public float delayBeforeNextWave = 5f;
}
