using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] ShopManager sm;
    [SerializeField] DialogueManager dm;
    [SerializeField] DialogueType type;
    [SerializeField] bool isShop;
    [SerializeField] string charName;
    [SerializeField] List<string> dialogue;

    public void Talk()
    {
        if (!dm.isTalking)
        {
            switch (type)
            {
                case DialogueType.random:
                    int rand = Random.Range(0, dialogue.Count);
                    dm.StartCoroutine(dm.WriteDialogue(charName, dialogue[rand]));
                    break;
                case DialogueType.continuous:
                    StartCoroutine("TalkContinue");
                    break;
            }
        }
    }

    private IEnumerator TalkContinue()
    {
        foreach (string line in dialogue)
        {
            dm.StartCoroutine(dm.WriteDialogue(charName, line));
            yield return new WaitUntil(() => !dm.isTalking);
        }
        if (isShop)
        {
            sm.OpenShop();
        }
    }
}

enum DialogueType
{
    random, continuous
}