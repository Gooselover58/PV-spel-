using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRocketLauncher : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    [SerializeField] float coolDown;
    [SerializeField] float rocketDir;
    [SerializeField] GameObject player;
    private GameObject apTran;
    private BossScript bs;

    private void Start()
    {
        apTran = transform.GetChild(0).gameObject;
        bs = transform.parent.GetComponent<BossScript>();
        StartCoroutine("CoolDown");
    }

    IEnumerator CoolDown()
    {
        while (bs.isAlive)
        {
            yield return new WaitForSeconds(coolDown);
            if (bs.isAlive)
            {
                ShootRocket();
            }
        }
    }

    private void ShootRocket()
    {
        GameObject newRocket = Instantiate(rocket, apTran.transform.position, Quaternion.identity);
        newRocket.GetComponent<RocketScript>().player = player;
        newRocket.GetComponent<Rigidbody2D>().rotation = rocketDir;
    }
}
