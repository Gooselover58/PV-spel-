using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public bool hasSpawned;
    public int initDir;
    public RoomManager rm;
    public GameObject spawnPointHolder;
    public GameObject spawnPoint;
    public GameObject assignedRoom;
    public GameObject grid;
    private GameObject roomOb;
    private List<int> directions;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<SpawnPointScript>() != null && !hasSpawned)
        {
            CreateBlockade();
        }
    }

    public void Begin()
    {
        directions = assignedRoom.GetComponent<RoomScript>().directions.ToList();
        hasSpawned = false;
        Invoke("Initialise", 0.1f);
    }

    public void Initialise()
    {
        // 1 = vänster, 2 = upp, 3 = höger, 4 = ner
        roomOb = Instantiate(assignedRoom, transform.position, Quaternion.identity, grid.transform);
        if (directions.Contains(initDir))
        {
            directions.Remove(initDir);
        }
        foreach (int dir in directions.ToList())
        {
            switch (dir)
            {
                case 1:
                    CreateRoom(Vector2.left, 3, rm.leftRooms);
                    break;
                case 2:
                    CreateRoom(Vector2.up, 4, rm.topRooms);
                    break;
                case 3:
                    CreateRoom(Vector2.right, 1, rm.rightRooms);
                    break;
                case 4:
                    CreateRoom(Vector2.down, 2, rm.bottomRooms);
                    break;
            }
        }
    }

    private void CreateRoom(Vector2 dir, int from, GameObject[] rooms)
    {
        if (rm.roomAmount < 1)
        {
            rm.roomAmount--;
            GameObject newSpawnPoint = Instantiate(spawnPoint, transform.position * (dir * rm.distance), Quaternion.identity, spawnPointHolder.transform);
            SpawnPointScript sps = newSpawnPoint.GetComponent<SpawnPointScript>();
            sps.initDir = from;
            sps.rm = rm;
            sps.spawnPointHolder = spawnPointHolder;
            sps.spawnPoint = spawnPoint;
            int rand = Random.Range(0, rooms.Length);
            sps.assignedRoom = rooms[rand];
            sps.grid = grid;
            sps.Begin();
            hasSpawned = true;
        }
        else
        {
            CreateBlockade();
        }
    }

    private void CreateBlockade()
    {

    }
}
