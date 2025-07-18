using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<IWeapon> allWeapons = new List<IWeapon>();

    public WeaponType startingWeapon;

    private void Awake()
    {
        IWeapon[] foundWeapons = GetComponentsInChildren<IWeapon>();
    }
}
