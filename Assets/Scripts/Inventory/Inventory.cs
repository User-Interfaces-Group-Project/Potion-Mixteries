using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    /// <summary>
    /// Represents the types of items that can exist in the inventory. Each item is
    /// associated with specific game mechanics or quests. Ensure that the order of
    /// items in this enum matches the order of sprites in the <see cref="sprites"/>
    /// array to correctly map each item to its visual representation.
    /// </summary>
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

    /// <summary>
    /// Stores the inventory items, mapping each <see cref="InventoryItem"/> to its quantity.
    /// </summary>
    private Dictionary<InventoryItem, int> inventory = new Dictionary<InventoryItem, int>();

    /// <summary>
    /// Maps each <see cref="InventoryItem"/> to its corresponding <see cref="Sprite"/>.
    /// </summary>
    private Dictionary<InventoryItem, Sprite> itemSprites = new Dictionary<InventoryItem, Sprite>();
    /// <summary>
    /// An array of sprites representing the visual appearance of each inventory item.
    /// This array should be populated in the Unity Editor by dragging the appropriate
    /// Sprite assets onto this field. The order of sprites in this array should match the
    /// order of items defined in the <see cref="InventoryItem"/> enum to ensure correct
    /// mapping between items and their sprites.
    /// </summary>
    /// <example>
    /// For example, if the <see cref="InventoryItem.MorningDew"/> is the first item in the
    /// InventoryItem enum, then the first sprite in this array should be the sprite for
    /// Morning Dew.
    /// </example>
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
    /// <summary>
    /// Adds a specified quantity of an item to the inventory. If the item already exists, its quantity is increased.
    /// </summary>
    /// <param name="item">The item to add to the inventory.</param>
    /// <param name="quantity">The quantity of the item to be added.</param>
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
    /// <summary>
    /// Removes a specified quantity of an item from the inventory. If the resulting quantity is zero or less, the item is removed from the inventory.
    /// </summary>
    /// <param name="item">The item to be removed from the inventory.</param>
    /// <param name="quantity">The quantity of the item to be removed.</param>
    /// <returns>True if the item was successfully removed, false otherwise.</returns>
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

    /// <summary>
    /// Retrieves the sprite associated with a given inventory item.
    /// </summary>
    /// <param name="item">The inventory item whose sprite is to be retrieved.</param>
    /// <returns>The sprite associated with the specified item, or null if the item does not have an associated sprite.</returns>
    public Sprite GetSpriteForItem(InventoryItem item)
    {
        if (itemSprites.ContainsKey(item))
        {
            return itemSprites[item];
        }
        return null; // Return null or a default sprite if not found
    }
}
