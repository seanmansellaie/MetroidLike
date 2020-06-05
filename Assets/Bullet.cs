using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health)
        {
            health.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
