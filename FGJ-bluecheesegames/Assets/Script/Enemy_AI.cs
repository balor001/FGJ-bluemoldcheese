using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public Vector2 attackRange = new Vector2(1f, 1f);
    int attackDamage;
    public LayerMask playerLayer;



    EnemyStats enemyStats;

    public Vector2 attackOffset;



    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        attackDamage = enemyStats.attackDamage;


    }

    public void Attack()
    {
        //animator.SetTrigger("Attack"); // Play animation
        Collider2D colInfo = Physics2D.OverlapBox(attackPoint.position, attackRange, playerLayer); // hit enemies in range

        // Damage
        if (colInfo != null)
        {
            Debug.Log(name + " hit" + colInfo.name);
            colInfo.GetComponent<PlayerStats>().TakeDamage(attackDamage);
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
