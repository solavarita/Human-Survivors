using JetBrains.Annotations;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponDataSet", menuName = "Weapons/Weapon Data Set")]
public class WeaponDataSet : ScriptableObject
{
    public WeaponData[] weaponLevels; //list các level của một weapon
}
