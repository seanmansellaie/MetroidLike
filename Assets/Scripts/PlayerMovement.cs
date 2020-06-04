using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, crouchMoveSpeed, jumpSpeed, gravity = 9.81f, airGravity;
    public GameObject capsule, sphere;
    private bool isGrounded, isCrouching;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var currentMoveSpeed = isCrouching ? crouchMoveSpeed : moveSpeed;
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * currentMoveSpeed);
        var currentGravity = isGrounded ? gravity : airGravity;
        rb.AddForce(Vector3.down * currentGravity);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            capsule.SetActive(false);
            sphere.SetActive(true);
            isCrouching = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            capsule.SetActive(true);
            sphere.SetActive(false);
            isCrouching = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            isGrounded = true;
        }
    }

}
