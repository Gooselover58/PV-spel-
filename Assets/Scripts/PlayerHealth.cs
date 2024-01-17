using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    private MovmentScript ms;
    [SerializeField] private AudioSource takedmg; 
    public GameManager gm;
    public int maxHealth;
    public int health;

    private void Start()
    {
        ms = GetComponent<MovmentScript>();
        health = maxHealth;
    }

    private void Update()
    {
        gm.healthSlid.maxValue = maxHealth;
        gm.healthSlid.value = health;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(1); 
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        takedmg.Play();
        if (health <= 0)
        {
            ms.spring.mute = true; 
            takedmg.mute = true;
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
