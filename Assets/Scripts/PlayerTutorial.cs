using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTutorial : MonoBehaviour
{
    public bool hasKey;
    public bool hasMap;
    [SerializeField] GameObject[] obsAfterMap;

    private void Start()
    {
        foreach (GameObject ob in obsAfterMap)
        {
            ob.SetActive(false);
        }
        transform.position = new Vector3(-30.5f, -15.5f, 0f);
        hasKey = false;
        hasMap = false;
        StartCoroutine("WaitToSpawnEnemy");
    }

    IEnumerator WaitToSpawnEnemy()
    {
        yield return new WaitUntil(() => hasMap);
        foreach (GameObject ob in obsAfterMap)
        {
            ob.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LockedDoor") && hasKey)
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("TutExit") && hasMap)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
