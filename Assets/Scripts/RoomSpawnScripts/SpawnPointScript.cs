using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public GameObject room;
    public GameObject grid;
    public GameObject spawnPointHolder;
    public GameObject spawnPoint;
    public GameObject roomVisual;
    public List<int> roomDirections;
    public float distance;
    public int roomAmount;
    public int sentDir;
    public RoomManager cr;
    private bool hasSpawned;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<SpawnPointScript>() != null)
        {
            if (col.GetComponent<SpawnPointScript>().hasSpawned)
            {
                Destroy(roomVisual);
                Destroy(gameObject);
                CreateBlockade(sentDir, Vector2.zero);
            }
            else if (!col.GetComponent<SpawnPointScript>().hasSpawned && !hasSpawned)
            {
                Destroy(roomVisual);
                Destroy(gameObject);
                CreateBlockade(sentDir, Vector2.zero);
            }
        }
    }

    public void Begin(int dirr)
    {
        StartCoroutine(Spawn(dirr));
    }
    IEnumerator Spawn(int dirr)
    {
        yield return new WaitForSeconds(0.1f);
        hasSpawned = false;
        roomDirections = room.GetComponent<RoomScript>().roomDirections.ToList();
        if (roomDirections.Contains(dirr))
        {
            roomDirections.Remove(dirr);
        }
        roomVisual = Instantiate(room, transform.position, Quaternion.identity, grid.transform);
        foreach (int dir in roomDirections)
        {
            switch (dir)
            {
                case 1:
                    CreateRoom(cr.rightRooms, 3, Vector2.left);
                    break;
                case 2:
                    CreateRoom(cr.bottomRooms, 4, Vector2.up);
                    break;
                case 3:
                    CreateRoom(cr.leftRooms, 1, Vector2.right);
                    break;
                case 4:
                    CreateRoom(cr.topRooms, 2, Vector2.down);
                    break;
            }
        }
    }

    void CreateRoom(GameObject[] rooms, int dir, Vector2 pos)
    {
        if (cr.roomAmount > 0)
        {
            cr.roomAmount--;
            int room = Random.Range(0, rooms.Length);
            GameObject newRoom = Instantiate(spawnPoint, (Vector2)transform.position + (pos * distance), Quaternion.identity, spawnPointHolder.transform);
            /*if (cr.roomAmount == 0)
            {
                Instantiate(cr.gm.exitOb, new Vector2(transform.position.x + 1.1f, transform.position.y), Quaternion.identity);
            }*/
            SpawnPointScript sps = newRoom.GetComponent<SpawnPointScript>();
            sps.grid = grid;
            sps.spawnPointHolder = spawnPointHolder;
            sps.spawnPoint = spawnPoint;
            sps.cr = cr;
            sps.distance = distance;
            sps.sentDir = dir;
            sps.room = rooms[room];
            hasSpawned = true;
            sps.Begin(dir);
        }
        else
        {
            CreateBlockade(dir, pos);
        }
    }

    void CreateBlockade(int dir, Vector2 pos)
    {
        float dis = 9.5f;
        if (pos == Vector2.zero)
        {
            dis = 10.5f;
            switch (dir)
            {
                case 1:
                    pos = Vector2.left;
                    break;
                case 2:
                    pos = Vector2.up;
                    break;
                case 3:
                    pos = Vector2.right;
                    break;
                case 4:
                    pos = Vector2.down;
                    break;
            }
            if (dir > 2)
            {
                dir -= 2;
            }
            else
            {
                dir += 2;
            }
        }
        if (dir % 2 == 0)
        {
            Instantiate(cr.topBottomBlock, (Vector2)transform.position + (pos * dis), Quaternion.identity, spawnPointHolder.transform);
        }
        else
        {
            Instantiate(cr.leftRightBlock, (Vector2)transform.position + (pos * dis), Quaternion.identity, spawnPointHolder.transform);
        }
    }
}