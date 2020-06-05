using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP;
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
