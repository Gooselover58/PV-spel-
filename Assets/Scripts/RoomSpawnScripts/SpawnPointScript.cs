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
            CreateBlockade(0);
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
            CreateBlockade(from);
        }
    }

    private void CreateBlockade(int dirr)
    {
        if (dirr > 2)
        {
            dirr = initDir - 2;
        }
        else
        {
            dirr = initDir + 2;
        }
        Vector2 dir = Vector2.zero;
        switch (dirr)
        {
            case 1:
                dir = Vector2.left;
                break;
            case 2:
                dir = Vector2.up;
                break;
            case 3:
                dir = Vector2.right;
                break;
            case 4:
                dir = Vector2.down;
                break;
        }
        if (dirr % 2 == 0)
        {
            Instantiate(rm.topbottomBlock, transform.position * (dir * rm.distance / 2), Quaternion.identity, spawnPointHolder.transform);
        }
        else
        {
            Instantiate(rm.rightleftBlock, transform.position * (dir * rm.distance / 2), Quaternion.identity, spawnPointHolder.transform);
        }
    }
}
