using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] DialogueType type;
    [SerializeField] string charName;
    [SerializeField] string[] dialogue;

    public void Talk()
    {
        switch (type)
        {
            case DialogueType.random:

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