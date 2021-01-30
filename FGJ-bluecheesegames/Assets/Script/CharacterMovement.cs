﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    public Animator animator;
    float horizontalInput = 0f;
    bool jump = false;

    public float runSpeed = 40f;
    

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()

    {

        if (!characterController.m_Grounded)
        {
            if (!animator.GetBool("InAir"))
            {
            animator.SetBool("InAir", true);
            animator.SetTrigger("Jump");
            }
        }
        else animator.SetBool("InAir", false);
        
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true; 
        }
        
    }

    private void FixedUpdate()
    {
        // Moves player
        characterController.Move(horizontalInput * runSpeed * Time.fixedDeltaTime, false, jump);
        
        jump = false;

    }
}
