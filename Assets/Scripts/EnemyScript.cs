using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Enemy enemy;
    public bool isAlerted;
    public int hp;
    private GameObject player;
    private ParticleSystem bloodPart;

    private void Awake()
    {
        isAlerted = false;
        hp = enemy.health;
        bloodPart = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!isAlerted)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, enemy.agroRange);
            foreach (Collider2D col in cols)
            {
                if (col.GetComponent<MovmentScript>() != null)
                {
                    player = col.gameObject;
                    isAlerted = true;
                    break;
                }
            }
        }
        else
        {

        }
    }

    public void TakeDamage(int dmg)
    {
        bloodPart.Play();
        hp -= dmg;
        isAlerted = true;
    }
}
