using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    private SpriteRenderer sr;
    public Item item;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.itemArt;
    }
}
