using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject[] enemy;
    public void SpawnEnemies(List<GameObject> rooms)
    {
        foreach (GameObject room in rooms.ToList())
        {
            if (room != null)
            {
                int rand = Random.Range(1, 3);
                int randEn = Random.Range(1, 4);
                int whichEn;
                if (randEn == 1)
                {
                    whichEn = 1;
                }
                else
                {
                    whichEn = 0;
                }
                for (int i = 0; i < rand; i++)
                {
                    Instantiate(enemy[whichEn], room.transform.position, Quaternion.identity);
                }
            }
        }
        gm.stopLoading();
    }
}
