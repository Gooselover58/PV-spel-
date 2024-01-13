using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public void SpawnEnemies(List<GameObject> rooms)
    {
        foreach (GameObject room in rooms.ToList())
        {
            int rand = Random.Range(1, 3);
            for (int i = 0; i < 0; i++)
            {
                Instantiate(enemy, room.transform.position, Quaternion.identity);
            }
        }
    }
}
