using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource takedmg; 
    [SerializeField] GameManager gm;
    public int maxHealth;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        gm.healthSlid.maxValue = maxHealth;
        gm.healthSlid.value = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        takedmg.Play(); 
        if (health <= 0)
        {
            takedmg.mute = true; 
            Die();
        }

    }

    public void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gm.PlayerDead();
    }
}
