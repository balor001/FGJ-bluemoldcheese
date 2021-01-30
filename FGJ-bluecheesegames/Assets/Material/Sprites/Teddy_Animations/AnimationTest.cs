

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{

    private Animator playerAnim;
    private int state;

    // Use this for initialization
    void Start()
    {

        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            state = 1;
        }

        if (Input.GetKey(KeyCode.X))
        {
            state = 2;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            state = 3;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            state = 4;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            state = 5;
        }

        if (Input.GetKey(KeyCode.C))
        {
            state = 6;
        }





    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case 1:
                playerAnim.Play("Player_Walk", 0);
                break;
            case 2:
                playerAnim.Play("Player_Jump", 0);
                break;
            case 3:
                playerAnim.Play("Player_Idle", 0);
                break;
            case 4:
                playerAnim.Play("Player_Swing", 0);
                break;
            case 5:
                playerAnim.Play("Player_JumpSwing", 0);
                break;
            case 6:
                playerAnim.Play("Player_Landing", 0);
                break;
            default:
                playerAnim.Play("Player_Idle", 0); 
                break;
        }
    }
}

