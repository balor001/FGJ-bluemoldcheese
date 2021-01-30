

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

        if (Input.GetKey(KeyCode.Space))
        {
            state = 2;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            state = 3;
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
                playerAnim.Play("Player_Swing", 0);
                break;
            case 3:
                playerAnim.Play("Player_Idle", 0);
                break;
            default:
                playerAnim.Play("Player_Idle", 0); 
                break;
        }
    }
}

