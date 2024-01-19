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

    private void Start()
    {
        scrollSpeedSlider.maxValue = 1;
        scrollSpeedSlider.value = 0.1f;
        scrollSpeed = scrollSpeedSlider.value;
        textOb.transform.position = textSpawn;
    }

    private void Update()
    {
        textOb.Translate(Vector3.up * scrollSpeed);
        scrollSpeed = scrollSpeedSlider.value;
    }
}
