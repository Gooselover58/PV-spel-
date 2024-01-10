using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public float distance;
    public int roomAmount;
    public GameObject[] leftRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject rightleftBlock;
    public GameObject topbottomBlock;
    [SerializeField] GameManager grid;
    [SerializeField] GameObject spawnPointHolder;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject entrance;

    private void Start()
    {
        foreach (GameObject room in leftRooms)
        {
            if (room.GetComponent<RoomScript>().directions.Contains(1))
            {
                room.GetComponent<RoomScript>().directions.Remove(1);
            }
            room.GetComponent<RoomScript>().directions.Add(1);
        }
        foreach (GameObject room in topRooms)
        {
            if (room.GetComponent<RoomScript>().directions.Contains(2))
            {
                room.GetComponent<RoomScript>().directions.Remove(2);
            }
            room.GetComponent<RoomScript>().directions.Add(2);
        }
        foreach (GameObject room in rightRooms)
        {
            if (room.GetComponent<RoomScript>().directions.Contains(3))
            {
                room.GetComponent<RoomScript>().directions.Remove(3);
            }
            room.GetComponent<RoomScript>().directions.Add(3);
        }
        foreach (GameObject room in bottomRooms)
        {
            if (room.GetComponent<RoomScript>().directions.Contains(4))
            {
                room.GetComponent<RoomScript>().directions.Remove(4);
            }
            room.GetComponent<RoomScript>().directions.Add(4);
        }
        SpawnFloor();
    }
    public void SpawnFloor()
    {
        GameObject entrance = Instantiate(spawnPoint, transform.position, Quaternion.identity, spawnPointHolder.transform);
        SpawnPointScript sps = entrance.GetComponent<SpawnPointScript>();
        sps.initDir = 0;
        sps.rm = this;
        sps.spawnPointHolder = spawnPointHolder;
        sps.spawnPoint = spawnPoint;
        sps.assignedRoom = entrance;
        sps.Begin();
    }
}
