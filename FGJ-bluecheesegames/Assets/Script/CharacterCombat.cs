using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.6f;
    public LayerMask enemyLayers;
    int damageDealt;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        damageDealt = playerStats.attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();

                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            playerStats.TakeDamage(10);
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // Play animation

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // deteck enemies in range

        // Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<EnemyStats>().TakeDamage(damageDealt);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
