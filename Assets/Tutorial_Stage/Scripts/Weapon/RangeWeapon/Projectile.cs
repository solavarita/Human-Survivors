using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;

    private WeaponData weaponData;

    public void Launch(Vector2 direction, float speed, WeaponData data)
    {
        this.weaponData = data;
        moveSpeed = speed;

        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            moveDirection = (nearestEnemy.transform.position - transform.position).normalized;
        }
        else
        {
            moveDirection = direction.normalized;
        }

        if (TryGetComponent(out SpriteRenderer sr))
            sr.flipX = moveDirection.x < 0;

        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private GameObject FindNearestEnemy()
    {
        if (weaponData == null) return null;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDist && dist <= weaponData.range)
            {
                minDist = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Bắn đạn trúng");
            // Optional: Destroy(gameObject);
        }
    }
}
