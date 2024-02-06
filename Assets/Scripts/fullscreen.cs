using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreen : MonoBehaviour
{
    public void change()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
