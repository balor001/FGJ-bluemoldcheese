using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_AI : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public Vector2 attackRange = new Vector2(1f, 1f);
    int damageDealt;
    public LayerMask playerLayer;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    EnemyStats enemyStats;
    AIPath aIPath;
    public Enemy_Turner enemy_Turner;

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        aIPath = GetComponent<AIPath>();
        //enemy_Turner = GetComponent<Enemy_Turner>();

        damageDealt = enemyStats.attackDamage;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(aIPath.velocity.x));
    }

    private void Update()
    {
        if (aIPath.reachedEndOfPath && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // Play animation

        Collider2D[] hitCharacter = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, playerLayer); // deteck enemies in range

        // Damage
        foreach (Collider2D character in hitCharacter)
        {
            if (enemy_Turner.AttackReached)
            {
                Debug.Log("We hit" + character.name);
                character.GetComponent<PlayerStats>().TakeDamage(damageDealt);
                enemy_Turner.AttackReached = false;
            }

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireCube(attackPoint.position, attackRange);
    }
}
