using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    
    float horizontalInput = 0f;
    bool jump = false;
    bool crouch = false;

    public float runSpeed = 40f;
    

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()

    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Moves player
        characterController.Move(horizontalInput * runSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
