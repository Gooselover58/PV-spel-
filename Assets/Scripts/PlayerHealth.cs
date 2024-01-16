using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int baseHealth;
    public int health;

    private void Start()
    {
        health = baseHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
