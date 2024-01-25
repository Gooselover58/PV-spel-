using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] List<string> texts;

    private void Start()
    {
        texts.Add("Hello");
        texts.Add("Goodbye");
        texts.Add("Do you feel alright?");
        foreach (string text in texts)
        {
            StartCoroutine(testCoRoutine(text));
        }
    }

    IEnumerator testCoRoutine(string text)
    {
        yield return new WaitForSeconds(2);
        Debug.Log(text);
        if (text != "Goodbye")
        {
            texts.Remove(text);
        }
    }
}
