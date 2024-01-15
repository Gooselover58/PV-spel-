using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] TextMeshProUGUI loadText;
    private bool isLoading;

    private void Start()
    {
        isLoading = true;
        LoadingScreen.SetActive(true);
        StartCoroutine("Loading");
    }

    public void stopLoading()
    {
        isLoading = false;
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
