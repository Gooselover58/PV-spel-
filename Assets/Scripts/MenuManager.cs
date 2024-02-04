using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button sB;
    [SerializeField] Button eB;
    [SerializeField] Toggle seB;
    [SerializeField] GameObject[] obsAfterFade;
    [SerializeField] Image fadeIM;

    private void Start()
    {
        fadeIM.color = new Color(0, 0, 0, 0);
        fadeIM.gameObject.SetActive(false);
        sB.interactable = true;
        eB.interactable = true;
        seB.interactable = true;
    }
    public void StartGame()
    {
        sB.interactable = false;
        eB.interactable = false;
        seB.interactable = false;
        StartCoroutine("Fade");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    IEnumerator Fade()
    {
        fadeIM.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            fadeIM.color = new Color(0, 0, 0, (i / 10f + 0.1f));
            yield return new WaitForSeconds(0.1f);
        }
        foreach (GameObject ob in obsAfterFade)
        {
            ob.SetActive(true);
        }
    }
}       
    