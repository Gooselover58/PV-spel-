using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] DialogueType type;
    [SerializeField] string charName;
    [SerializeField] List<string> dialogue;

    public void Talk()
    {
        switch (type)
        {
            case DialogueType.random:
                int rand = Random.Range(0, dialogue.Count);
                Debug.Log(dialogue[rand]);
                break;
            case DialogueType.continuous:
                break;
        }
    }
}

enum DialogueType
{
    random, continuous
}