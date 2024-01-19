using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] Vector3 textSpawn;
    [SerializeField] Slider scrollSpeedSlider;
    [SerializeField] RectTransform textOb;
    [SerializeField] RectTransform textObTwo;

    private void Start()
    {
        scrollSpeedSlider.maxValue = 1;
        scrollSpeedSlider.value = 0.1f;
        scrollSpeed = scrollSpeedSlider.value;
        textOb.transform.position = textSpawn;
        textObTwo.transform.position = textSpawn;
    }

    private void Update()
    {
        scrollSpeed = scrollSpeedSlider.value;
        if (textOb.position.y < 2100)
        {
            textOb.Translate(Vector3.up * scrollSpeed);
        }
        else if (textObTwo.position.y < 1400)
        {
            textObTwo.Translate(Vector3.up * scrollSpeed);
        }
        else
        {
            Application.Quit();
        }
    }
}
