using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] TextMeshProUGUI loadText;
    private bool isLoading;

    private void Start()
    {
        isLoading = true;
        LoadingScreen.SetActive(true);
        GameOverScreen.SetActive(false);
        StartCoroutine("Loading");
    }

    public void stopLoading()
    {
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
