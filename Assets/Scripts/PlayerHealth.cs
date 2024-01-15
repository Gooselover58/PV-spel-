using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] int baseHealth;
    public int health;

    private void Start()
    {
        health = baseHealth;
        gm.healthSlid.maxValue = baseHealth;
    }

    private void Update()
    {
        gm.healthSlid.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gm.PlayerDead();
    }
}
