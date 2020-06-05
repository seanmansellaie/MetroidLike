using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrel;
    public float refireRate, muzzleVelocity;
    private float refireRateTimer;
    private Rigidbody playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
   
    private void Update()
    {
        refireRateTimer += Time.deltaTime;
        if (Input.GetButton("Shoot") && refireRateTimer >= refireRate)
        {
            var bulletRB = Instantiate(bulletPrefab, barrel.position, barrel.rotation).GetComponent<Rigidbody>();
            bulletRB.AddForce(playerRB.velocity + bulletRB.transform.forward * muzzleVelocity, ForceMode.Impulse);
            refireRateTimer = 0;
        }
    }
}
