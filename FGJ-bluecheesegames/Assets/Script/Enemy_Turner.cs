using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Turner : MonoBehaviour
{
    public AIPath aiPath;
    bool attackReached = false;
    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        Debug.Log(AttackReached);
    }

    public void FrameReached()
    {
        AttackReached = true;
    }

    public bool AttackReached
    {
        get { return attackReached; }

        set { attackReached = value; }
    }
}
