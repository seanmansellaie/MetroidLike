using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, crouchMoveSpeed, jumpSpeed, gravity = 9.81f, airGravity, slowdownSpeed;
    public int maxJumps;
    public GameObject capsule, sphere;
    private bool isCrouching;
    private Rigidbody rb;
    private int currentJumps;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var currentMoveSpeed = isCrouching ? crouchMoveSpeed : moveSpeed;
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * currentMoveSpeed);
        var currentGravity = currentJumps == 0 ? gravity : airGravity;
        rb.AddForce(Vector3.down * currentGravity);
        if (Input.GetAxis("Horizontal") == 0)
        {
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.zero, slowdownSpeed);
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            currentJumps++;
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
            currentJumps = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            if (currentJumps == 0)
                currentJumps++;
        }
    }

}
