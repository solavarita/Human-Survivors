using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWeapon : Weapon
{
    public GameObject areaWeaponPrefabs;
    public Vector2 offset;
    [SerializeField] private float animTimes;

    protected override void TryAttack()
    {
        StartCoroutine(DelayedSpawn());
    }
    private IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(animTimes); // Chờ 3 giây

        Vector3 spawnPos = transform.position + (Vector3)offset;
        GameObject areaEffect = Instantiate(areaWeaponPrefabs, spawnPos, Quaternion.identity, this.transform);
        AreaDamage areaDamage = areaEffect.GetComponent<AreaDamage>();

        if (areaDamage != null)
        {
            areaDamage.Setup(weaponData.damage, weaponData.range);
        }

        Destroy(areaEffect, animTimes); // Vẫn destroy sau 3s nếu muốn
    }
}
