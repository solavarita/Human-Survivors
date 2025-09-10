using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Định danh enemy")]
    [Tooltip("Key này phải trùng với prefab name hoặc key trong pool")]
    public string enemyKey; // phải trùng tên prefab để kết nối
    public GameObject prefab;

    [Header("Stats")]
    public float moveSpeed;
    public int maxHealth;
    public int damage;
    public Sprite icon; // optional: để show UI hoặc preview    
}
