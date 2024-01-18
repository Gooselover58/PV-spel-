using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] GameObject Exit;
    [SerializeField] GameObject dItem;
    [SerializeField] GameObject[] enemy;
    [SerializeField] Item[] itemsThatSpawn;
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
                Instantiate(Exit, rooms[i].transform.position - new Vector3(1.5f, -1.5f, 0), Quaternion.identity);
                rooms.Remove(rooms[i]);
                break;
            }
        }
        foreach (GameObject room in rooms.ToList())
        {
            bool hasSpawnedItem = false;
            if (room != null)
            {
                int shouldItem = Random.Range(1, 7);
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
                    if (shouldItem == 5 && !hasSpawnedItem)
                    {
                        hasSpawnedItem = true;
                        int rItem = Random.Range(0, itemsThatSpawn.Length);
                        GameObject newItem = Instantiate(dItem, room.transform.position, Quaternion.identity);
                        newItem.GetComponent<DroppedItem>().item = itemsThatSpawn[rItem];
                        enemies.Add(newItem);
                    }
                }
            }
        }
        gm.stopLoading();
    }
}
