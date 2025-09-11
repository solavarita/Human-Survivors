using UnityEngine;

public enum WeaponType { Melee, Ranged, AoE }

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Loại vũ khí")]
    public WeaponType type;

    [Header("Prefabs vũ khí")]
    public GameObject weaponPrefabs;

    [Header("Thông số cơ bản")]    
    public float attackInterval; // khoảng thời gian giữa 2 lần tấn công
    public float damage; // sát thương
    public float projectileSpeed; // tốc độ đạn
    public float range; // tầm xa

    [Header("Mô tả vũ khí")]
    public string weaponName;
    public string weaponDescription;

    [Header("Next Level")]
    public WeaponData nextLevel;
}
