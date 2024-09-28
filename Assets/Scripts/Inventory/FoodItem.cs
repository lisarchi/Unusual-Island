using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/New Food Item")]

public class FoodItem : ItemScriptableObjects
{
    public float hillAmount;

    private void Start()
    {
        itemType = ItemType.Food;
    }
}
