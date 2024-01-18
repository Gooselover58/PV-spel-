using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class BossRocketLauncher : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    [SerializeField] float coolDown;
    [SerializeField] float rocketDir;
    [SerializeField] GameObject player;
    private GameObject apTran;

    private void Start()
    {
        apTran = transform.GetChild(0).gameObject;
        StartCoroutine("CoolDown");
    }

    IEnumerator CoolDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolDown);
            ShootRocket();
        }
    }

    private void ShootRocket()
    {
        GameObject newRocket = Instantiate(rocket, apTran.transform.position, Quaternion.identity);
        newRocket.GetComponent<RocketScript>().player = player;
        newRocket.GetComponent<Rigidbody2D>().rotation = rocketDir;
    }
}
