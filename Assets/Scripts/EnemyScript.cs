using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int hp;

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }
}
