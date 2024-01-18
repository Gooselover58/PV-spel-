using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    private MovmentScript ms;
    [SerializeField] AudioSource takedmg;
    [SerializeField] AudioSource LowHp;
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
        if (gm.isGameActive)
        {
            health -= damage;
            takedmg.Play();
            if (health <= 0)
            {
                LowHp.mute = true; 
                ms.spring.mute = true;
                takedmg.mute = true;
                Die();
            }
            if (health <= 20)
            {
                LowHp.Play(); 
            }
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
