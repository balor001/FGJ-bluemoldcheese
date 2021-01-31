using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Pathing : MonoBehaviour
{
    public int currentWayPoint = 0;
    public Path path;


    Seeker seeker;
    Rigidbody2D rb;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, player.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
}
