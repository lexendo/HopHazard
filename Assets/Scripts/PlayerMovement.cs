using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] Animator playerAnimator;

    bool isMoving = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isMoving = (horizontalInput != 0 || verticalInput != 0);
        playerAnimator.SetBool("Running", isMoving);


        playerAnimator.SetBool("Falling", !IsGrounded());

        playerAnimator.SetBool("RunLeft", horizontalInput < 0 && verticalInput >= 0);
        playerAnimator.SetBool("RunRight", horizontalInput > 0 && verticalInput >= 0);
        playerAnimator.SetBool("RunBackward", verticalInput < 0 && horizontalInput == 0);
        playerAnimator.SetBool("RunForward", verticalInput > 0 && horizontalInput == 0);
        playerAnimator.SetBool("RunBackwardLeft", verticalInput < 0 && horizontalInput < 0);
        playerAnimator.SetBool("RunBackwardRight", verticalInput < 0 && horizontalInput > 0);

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerAnimator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpSound.Play();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.3f, ground);
    }
}