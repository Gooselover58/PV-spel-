using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStarter : MonoBehaviour
{
    public GameObject boss;

    public void ActivateBoss()
    {
        boss.SetActive(true);
        Destroy(gameObject);
    }
}
