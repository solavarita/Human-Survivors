using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyKey; // phải trùng tên prefab để kết nối
    public float speed;
    public int maxHealth;
    public int damage;
    public Sprite icon; // optional: để show UI hoặc preview

    // Em có thể thêm: animationClip, soundClip, AIType...
}
