using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement Instance;
    [SerializeField] private float enemySpeed;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Rigidbody2D enemyRB;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Collider2D enemyCollider;

    public Transform playerTarget;
    public string originalPrefabKey { get; set; }
    public EnemyData data;

    private bool isDead = false;

    private void Awake()
    {
        UnFreezeEnemy();
        Instance = this;
    }

    private void Start()
    {
        isDead = false;
        playerTarget = PlayerMovement.Instance.transform;
        enemyRB.gameObject.SetActive(true);
        if (data != null)
        {
            enemySpeed = data.speed;
            // maxHealth = data.maxHealth;
            // damage = data.damage;
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            EnemyMove();
            FlipDirection();
        }
    }

    private void EnemyMove()
    {
        Vector2 direction = (playerTarget.position - transform.position).normalized;
        enemyRB.MovePosition(enemyRB.position + direction * enemySpeed * Time.fixedDeltaTime);
    }

    private void FlipDirection()
    {
        enemySprite.flipX = transform.position.x < playerTarget.position.x;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement.Instance.TakeDamage(3);
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        enemyAnimator.SetBool("isDead", true);
        FreezeEnemy();

        ExpOrbPooling.Instance.SpawnExpOrb(transform.position);

        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
        // Cho animator kịp vào đúng state
        yield return new WaitForSeconds(0.05f);

        // Đợi animation death chạy hết
        float duration = enemyAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(duration);

        ResetEnemy();
        EnemyPooling.Instance.ReturnEnemyToPool(gameObject, originalPrefabKey);
    }

    private void FreezeEnemy()
    {
        enemyRB.bodyType = RigidbodyType2D.Kinematic;
        enemyCollider.enabled = false;
    }

    private void UnFreezeEnemy()
    {
        enemyRB.bodyType = RigidbodyType2D.Dynamic;
        enemyCollider.enabled = true;
    }

    public void ResetEnemy()
    {
        isDead = false;
        enemyAnimator.SetBool("isDead", false);
        UnFreezeEnemy();
    }
}
