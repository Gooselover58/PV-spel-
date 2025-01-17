using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        transform.position = player.position + offset;
    }
}
