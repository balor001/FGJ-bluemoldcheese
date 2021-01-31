using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Run : StateMachineBehaviour
{
    public float speed = 300f;
    public float attackRange = 3f;
    public float nextWayPointDistance = 3f;
    public float attackRate = 2f;

    float nextAttackTime = 0f;
    bool reachedEndOfPath = false;


    Transform thisTransform;
    Transform player;
    Rigidbody2D rb;
    Enemy_Turner turner;
    Pathing pathing;
    CharacterStats characterStats;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        turner = animator.GetComponent<Enemy_Turner>();
        pathing = animator.GetComponent<Pathing>();
        characterStats = animator.GetComponent<CharacterStats>();
        thisTransform = animator.transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pathing.path == null || characterStats.Died)
        {
            return;
        }
        if (pathing.currentWayPoint >= pathing.path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)pathing.path.vectorPath[pathing.currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;
        rb.AddForce(force);
        Debug.Log(force);
        float distance = Vector2.Distance(rb.position, pathing.path.vectorPath[pathing.currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            pathing.currentWayPoint++;
        }

        //if (force.x >= 0.01f)
        //{
        //    thisTransform.localScale = new Vector3(-1f, 1f, 1f);
        //}
        //else if (force.x <= -0.01f)
        //{
        //    thisTransform.localScale = new Vector3(1f, 1f, 1f);
        //}
        turner.LookAtPlayer();

        //Vector2 target = new Vector2(player.position.x, rb.position.y);
        //Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        //
        //rb.MovePosition(newPos);
        //
        if (Vector2.Distance(player.position, rb.position) <= attackRange && Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");
            rb.MovePosition(animator.transform.position);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
