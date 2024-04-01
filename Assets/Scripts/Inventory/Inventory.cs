using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public enum InventoryItem
    {
        MorningDew,
        CampfireAsh,
        ClearQuartz,
        BeechBark,
        Ginseng,
        Cloves,
        ParchmentDippedInInk,
        Beeswax,
        CrowFeather,
        JellyfishVenom,
        RoseBuds,
        Absinthe,
        BlackCatFur,
        Nightshade,
        OakRoot,
        DandelionStem,
        GoldfishScale,
        AntLegs,
        PuppysEyelash,
        LadybugWing
    }

    private Dictionary<InventoryItem, int> inventory = new Dictionary<InventoryItem, int>();
    private Dictionary<InventoryItem, Sprite> itemSprites = new Dictionary<InventoryItem, Sprite>();

    [SerializeField] private Sprite[] sprites; // Assign these in the Unity Editor

    void Start()
    {
        InitializeItemSprites();

        // Example: Initialize inventory with one of each item
        foreach (InventoryItem item in System.Enum.GetValues(typeof(InventoryItem)))
        {
            AddItem(item, 1);
        }
    }

    void InitializeItemSprites()
    {
        int i = 0;
        foreach (InventoryItem item in System.Enum.GetValues(typeof(InventoryItem)))
        {
            if (i < sprites.Length)
            {
                itemSprites[item] = sprites[i++];
            }
        }
    }

    public void AddItem(InventoryItem item, int quantity)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] += quantity;
        }
        else
        {
            inventory.Add(item, quantity);
        }
    }

    public bool RemoveItem(InventoryItem item, int quantity)
    {
        if (inventory.ContainsKey(item) && inventory[item] >= quantity)
        {
            inventory[item] -= quantity;
            if (inventory[item] <= 0)
            {
                inventory.Remove(item);
            }
            return true;
        }
        return false;
    }

    // For debugging: Print the inventory and display sprites in the console
    void PrintInventory()
    {
        foreach (var item in inventory)
        {
            Debug.Log($"{item.Key}: {item.Value}, Sprite: {itemSprites[item.Key].name}");
        }
    }

    // Method to retrieve the sprite for a given item
    public Sprite GetSpriteForItem(InventoryItem item)
    {
        if (itemSprites.ContainsKey(item))
        {
            return itemSprites[item];
        }
        return null; // Return null or a default sprite if not found
    }
}
