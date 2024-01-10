using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform shootPoint;

    private void Start()
    {
        shootPoint = transform.GetChild(0);
    }
    public void Attack()
    {

    }
}