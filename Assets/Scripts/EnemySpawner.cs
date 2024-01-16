using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject Exit;
    [SerializeField] GameObject[] enemy;
    public List<GameObject> enemies;

    private void Start()
    {
        enemies.Clear();
    }
    public void SpawnEnemies(List<GameObject> rooms)
    {
        rooms = rooms.ToList();
        for (int i = rooms.Count - 1; i > 0; i--)
        {
            if (rooms[i] != null)
            {
                Instantiate(Exit, rooms[i].transform.position - new Vector3(-1.5f, 1.5f, 0), Quaternion.identity);
                rooms.Remove(rooms[i]);
                break;
            }
        }
        foreach (GameObject room in rooms.ToList())
        {
            if (room != null)
            {
                int rand = Random.Range(1, 3);
                for (int i = 0; i < rand; i++)
                {
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
                    Vector3 spawn = room.transform.position - new Vector3(-1.5f, 1.5f, 0);
                    Vector3 extraSpawn = new Vector3(Random.Range(-3f, 3f), Random.Range(-2f, 2f), 0);
                    GameObject newEnemy = Instantiate(enemy[whichEn], spawn + extraSpawn, Quaternion.identity);
                    enemies.Add(newEnemy);
                }
            }
        }
        gm.stopLoading();
    }
}
