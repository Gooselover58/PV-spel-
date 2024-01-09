using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int roomAmount;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject entrance;
    [SerializeField] GameObject[] leftRooms;
    [SerializeField] GameObject[] topRooms;
    [SerializeField] GameObject[] rightRooms;
    [SerializeField] GameObject[] bottomRooms;
    [SerializeField] GameObject rightleftBlock;
    [SerializeField] GameObject topbottomBlock;

    public void SpawnFloor()
    {

    }
}
