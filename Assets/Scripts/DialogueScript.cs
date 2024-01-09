using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] DialogueType type;
    [SerializeField] string charName;
    [SerializeField] string[] dialogue;
}

enum DialogueType
{
    Random, Continuous
}