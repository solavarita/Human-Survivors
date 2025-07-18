using UnityEngine;

public enum WeaponType { Melee, Ranged, AoE }

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Loại vũ khí")]
    public WeaponType type;

    [Header("Prefab Đạn")]
    public GameObject projectilePrefab;

    [Header("Prefab Area Weapon")]
    public GameObject areaWeaponPrefab;

    [Header("Thông số cơ bản")]    
    public float attackInterval;
    public float damage;
    public float projectileSpeed;
    public float range;

    [Header("Mô tả vũ khí")]
    public string weaponName;
    public string weaponDescription;

    [Header("Next Level")]
    public WeaponData nextLevel;
}
