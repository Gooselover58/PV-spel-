using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TextMeshProUGUI loadText;
    [SerializeField] RoomManager rm;
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
        foreach (GameObject enemy in rm.es.enemies)
        {
            yield return new WaitForSeconds(0.01f);
            Destroy(enemy.gameObject);
        }
        rm.spawnedRooms.Clear();
        rm.es.enemies.Clear();
        StartCoroutine("SpawnCamp");
    }

    public IEnumerator SpawnCamp()
    {
        Instantiate(refugeeCamp, new Vector3(0, 0, 0), Quaternion.identity);
        player.transform.position = campPos;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(2);
        stopLoading();
    }
}
