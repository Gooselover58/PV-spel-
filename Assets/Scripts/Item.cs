using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite itemArt;
    public ItemType itemType;
    public int increase;
}

public enum ItemType
{
    Buff, OneTimeUse, Instant
}