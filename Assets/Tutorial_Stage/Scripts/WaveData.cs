using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveData", menuName = "Enemy/Wave Data")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class EnemySpawnEvent
    {
        public float startTime;     // thời điểm bắt đầu
        public float endTime;       // thời điểm kết thúc
        public string[] enemyKey;  // key của prefab (tên)
        public float spawnInterval = 1f; // tốc độ spawn
        public int spawnCount = 1;       // số enemy spawn mỗi interval (ví dụ 25)
        public int maxEnemy = 0;         // 0 = unlimited tổng spawn trong event, >0 = tối đa (ví dụ 50)
        public int maxAlive = 0;         // 0 = không giới hạn theo event, >0 = tối đa alive của event đồng thời
    }

    public EnemySpawnEvent[] spawnEvents;
}
