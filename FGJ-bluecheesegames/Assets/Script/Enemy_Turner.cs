using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Turner : MonoBehaviour
{
    //public AIPath aiPath;
    //bool attackReached = false;
    //// Update is called once per frame
    //void Update()
    //{
    //    if (aiPath.desiredVelocity.x >= 0.01f)
    //    {
    //        transform.localScale = new Vector3(-1f, 1f, 1f);
    //    }
    //    else if (aiPath.desiredVelocity.x <= -0.01f)
    //    {
    //        transform.localScale = new Vector3(1f, 1f, 1f);
    //    }
    //}

    Transform player;
    public bool isFlipped = false;
    public float turnTime = 2f;

    float nextTurnTime = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (Time.time >= nextTurnTime)
        {
            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
            nextTurnTime = 1f+  Time.time + 1f / turnTime;
        }

    }
}
