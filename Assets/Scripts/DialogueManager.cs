using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool isTalking;
    private bool toSkip;
    private bool isDone;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    private void Start()
    {
        isTalking = false;
        dialogueBox.SetActive(false);
    }

    public IEnumerator WriteDialogue(string name, string dialogue)
    {
        dialogueBox.SetActive(true);
        toSkip = false;
        isDone = false;
        isTalking = true;
        nameText.text = name + ":";
        dialogueText.text = "\"";
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogueText.text += dialogue[i];
            if (!toSkip)
            {
                yield return new WaitForSeconds(0.05f);
            }
        }
        dialogueText.text += "\"";
        isDone = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isDone)
            {
                toSkip = true;
            }
            else
            {
                StopTalking();
            }
        }
    }

    public void StopTalking()
    {
        dialogueBox.SetActive(false);
        isTalking = false;
    }
}
