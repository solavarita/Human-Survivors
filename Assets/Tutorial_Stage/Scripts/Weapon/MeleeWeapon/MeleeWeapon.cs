using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public GameObject meleeHitboxPrefab;
    [SerializeField] private float offsetAttackX;
    [SerializeField] private float offsetAttackY;

    private float lastFacingX = 1f;


    protected override void TryAttack()
    {
        float lastX = PlayerMovement.Instance.animator.GetFloat("lastX");

        if (Mathf.Abs(lastX) > 0.01f)
        {
            lastFacingX = Mathf.Sign(lastX);
        }

        Vector3 spawnPos = transform.position;
        Vector3 offset = new Vector3(lastFacingX * offsetAttackX, offsetAttackY, 0);
        Vector3 finalSpawnPos = spawnPos + offset;

        GameObject hitbox = Instantiate(meleeHitboxPrefab, finalSpawnPos, Quaternion.identity, this.transform);

        SpriteRenderer sr = hitbox.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.flipX = (lastFacingX < 0);
        }

        Destroy(hitbox, 0.42f);
    }
}
