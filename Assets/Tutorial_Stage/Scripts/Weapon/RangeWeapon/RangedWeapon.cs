using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Vector2 offset;
    protected override void TryAttack()
    {
        Vector3 spawnPos = transform.position + (Vector3)(offset * Mathf.Sign(transform.localScale.x));

        GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity, this.transform);

        Vector2 direction = new Vector2(Mathf.Sign(transform.localScale.x), 0f);

        Projectile projectileScript = proj.GetComponent<Projectile>();
        projectileScript.Launch(direction, projectileSpeed, weaponData);
    }
}
