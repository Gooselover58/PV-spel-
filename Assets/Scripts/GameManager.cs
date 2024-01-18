using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TextMeshProUGUI loadText;
    [SerializeField] RoomManager rm;
    [SerializeField] RoomManager rm2;
    [SerializeField] RoomManager rm3;
    [SerializeField] DialogueManager dm;
    [SerializeField] GameObject refugeeCamp;
    [SerializeField] Vector3 campPos;
    [SerializeField] Vector3 bossPos;
    private bool isLoading;
    public bool isGameActive;
    public Slider healthSlid;
    public GameObject player;
    public int whichLevel;

    private void Start()
    {
        whichLevel = 1;
        Time.timeScale = 1;
        player.transform.position = new Vector3(0, 0, 0);
        rm.SpawnLevel();
        StartCoroutine("Loading");
    }

    public void stopLoading()
    {
        isGameActive = true;
        HealthBar.SetActive(true);
        Inventory.SetActive(true);
        isLoading = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayerDead()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator Loading()
    {
        isLoading = true;
        isGameActive = false;
        LoadingScreen.SetActive(true);
        HealthBar.SetActive(false);
        Inventory.SetActive(false);
        GameOverScreen.SetActive(false);
        dm.StopTalking();
        loadText.text = "Loading";
        while (isLoading)
        {
            yield return new WaitForSeconds(0.2f);
            if (loadText.text == "Loading...")
            {
                loadText.text = "Loading";
            }
            else
            {
                loadText.text += ".";
            }
        }
        LoadingScreen.SetActive(false);
    }

    public IEnumerator RemoveLevel()
    {
        StartCoroutine("Loading");
        while (rm.grid.transform.childCount > 1)
        {
            yield return new WaitForSeconds(0.01f);
            Destroy(rm.grid.transform.GetChild(0).gameObject);
        }
        while (rm.spawnPointHolder.transform.childCount > 1)
        {
            yield return new WaitForSeconds(0.01f);
            Destroy(rm.spawnPointHolder.transform.GetChild(0).gameObject);
        }
        foreach (GameObject enemy in rm.es.enemies.ToList())
        {
            yield return new WaitForSeconds(0.01f);
            Destroy(enemy.gameObject);
        }
        rm.spawnedRooms.Clear();
        rm.es.enemies.Clear();
        SpawnCamp();
    }

    public void SpawnCamp()
    {
        player.transform.position = campPos;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        stopLoading();
    }

    public void SpawnNewLevel()
    {
        whichLevel++;
        player.transform.position = new Vector3(0, 0, 0);
        if (whichLevel == 2)
        {
            rm = rm2;
        }
        else if (whichLevel == 3)
        {
            rm = rm3;
        }
        else if (whichLevel == 4)
        {
            GoToBoss();
            return;
        }
        isGameActive = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rm.SpawnLevel();
        stopLoading();
        StopAllCoroutines();
        StartCoroutine("Loading");
    }

    private void GoToBoss()
    {
        player.transform.position = bossPos;
    }
}
