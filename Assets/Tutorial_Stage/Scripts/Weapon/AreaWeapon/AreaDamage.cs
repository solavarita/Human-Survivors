using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float range;

    public LayerMask enemyLayer;

    public void Setup(float dmg, float rng)
    {
        damage = dmg;
        range = rng;

        StartCoroutine(DelayedDamage());
    }

    private void ApplyDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent<EnemyMovement>(out var enemy))
            {
                Debug.Log("Area damage gây sát thương");
            }
        }
    }
    private IEnumerator DelayedDamage()
    {
        yield return new WaitForSeconds(0.2f); // delay trước khi gây sát thương
        ApplyDamage();
    }
}
