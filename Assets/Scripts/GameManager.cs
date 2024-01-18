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
    [SerializeField] GameObject refugeeCamp;
    [SerializeField] Vector3 campPos;
    private bool isLoading;
    public bool isGameActive;
    public Slider healthSlid;
    public GameObject player;

    private void Start()
    {
        isGameActive = false;
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
        LoadingScreen.SetActive(true);
        HealthBar.SetActive(false);
        Inventory.SetActive(false);
        GameOverScreen.SetActive(false);
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
    }

    public void SpawnNewLevel()
    {
        player.transform.position = new Vector3(0, 0, 0);
        rm = rm2;
        isGameActive = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("Spawning level 2");
        rm.SpawnLevel();
        stopLoading();
        StopAllCoroutines();
        StartCoroutine("Loading");
    }
}
