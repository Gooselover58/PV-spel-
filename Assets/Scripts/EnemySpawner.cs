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
            if (room != null)
            {
                int rand = Random.Range(1, 3);
                for (int i = 0; i < rand; i++)
                {
                    Instantiate(enemy, room.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
