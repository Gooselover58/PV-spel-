using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int roomAmount;
    public GameObject[] leftRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject rightleftBlock;
    public GameObject topbottomBlock;
    [SerializeField] GameManager grid;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject entrance;

    public void SpawnFloor()
    {

    }
}
