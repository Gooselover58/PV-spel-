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
    private bool isLoading;
    public bool isGameActive;
    public Slider healthSlid;

    private void Start()
    {
        isGameActive = false;
        Time.timeScale = 1;
        isLoading = true;
        LoadingScreen.SetActive(true);
        HealthBar.SetActive(false);
        Inventory.SetActive(false);
        GameOverScreen.SetActive(false);
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
}
