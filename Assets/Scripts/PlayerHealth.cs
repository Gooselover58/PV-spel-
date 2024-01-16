using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource takedmg; 
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
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(1); 
        }
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
