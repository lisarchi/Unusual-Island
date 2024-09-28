using UnityEngine;

public enum ItemType { Default, Food, Weapon, Instrument}

public class ItemScriptableObjects : ScriptableObject
{

    public string itemName;
    public int maximumAmount;
    public GameObject ItemObject;
    public Sprite icon;
    public ItemType itemType;
    public string itemDescription;
}
