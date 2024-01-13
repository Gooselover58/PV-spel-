using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject grid;
    [SerializeField] GameObject spawnPointHolder;
    [SerializeField] float roomDistance;
    [SerializeField] GameObject entrance;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] EnemySpawner es;
    public int roomAmount;
    public List<GameObject> spawnedRooms;
    public GameObject[] leftRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject leftRightBlock;
    public GameObject topBottomBlock;

    private void CreateFloor()
    {
        spawnedRooms.Clear();
        StartCoroutine("WaitForSpawn");
        AssignDirections();
    }

    void AssignDirections()
    {
        foreach (GameObject ob in leftRooms)
        {
            if (!ob.GetComponent<RoomScript>().roomDirections.Contains(1))
            {
                ob.GetComponent<RoomScript>().roomDirections.Add(1);
            }
        }
        foreach (GameObject ob in topRooms)
        {
            if (!ob.GetComponent<RoomScript>().roomDirections.Contains(2))
            {
                ob.GetComponent<RoomScript>().roomDirections.Add(2);
            }
        }
        foreach (GameObject ob in rightRooms)
        {
            if (!ob.GetComponent<RoomScript>().roomDirections.Contains(3))
            {
                ob.GetComponent<RoomScript>().roomDirections.Add(3);
            }
        }
        foreach (GameObject ob in bottomRooms)
        {
            if (!ob.GetComponent<RoomScript>().roomDirections.Contains(4))
            {
                ob.GetComponent<RoomScript>().roomDirections.Add(4);
            }
        }
        GameObject newEntrance = Instantiate(spawnPoint, transform.position, Quaternion.identity, spawnPointHolder.transform);
        SpawnPointScript sps = newEntrance.GetComponent<SpawnPointScript>();
        sps.cr = this;
        sps.distance = roomDistance;
        sps.grid = grid;
        sps.spawnPointHolder = spawnPointHolder;
        sps.spawnPoint = spawnPoint;
        sps.room = entrance;
        sps.sentDir = 0;
        sps.Begin(0);
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(0.1f * roomAmount);
        es.SpawnEnemies(spawnedRooms);
    }
}
