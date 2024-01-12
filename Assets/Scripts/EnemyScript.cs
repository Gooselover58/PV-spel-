using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool isAlerted;
    [SerializeField] int hp;
    [SerializeField] float radius;

    private void Awake()
    {
        isAlerted = false;
    }

    private void Update()
    {
        if (!isAlerted)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D col in cols)
            {
                if (col.GetComponent<MovmentScript>() != null)
                {
                    isAlerted = true;
                    break;
                }
            }
        }
        else
        {
            Debug.Log("ALERT!!!");
        }
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        isAlerted = true;
    }
}
