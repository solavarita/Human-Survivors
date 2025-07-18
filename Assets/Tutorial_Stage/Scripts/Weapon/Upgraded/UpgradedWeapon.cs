using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradedWeapon : MonoBehaviour
{
    public Weapon weapon;
    public void UpgradeWeapon()
    {
        weapon.weaponData = weapon.weaponData.nextLevel;
    }
}
