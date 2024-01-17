using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource CloseDie; 
    [SerializeField] private AudioSource DieSound; 
    [SerializeField] private AudioSource takedmg; 
    public GameManager gm;
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
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(1); 
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        takedmg.Play();
        if (health <= 10)
        {
            CloseDie.Play();
        }
        if (health <= 0)
        {
            DieSound.Play(); 
            takedmg.mute = true;
            CloseDie.mute = true; 
            Die();
        }
        


    }

    public void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gm.PlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyScript>() != null)
        {
            TakeDamage(maxHealth / 2);
        }
    }
}
