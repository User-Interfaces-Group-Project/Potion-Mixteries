using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        ParchmentInk,
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

    public GameObject inventoryShelf;
    public GameObject itemPrefab;
    public Text balanceText;
    public GameObject[] brewingSlots; // Assign these in the Unity Editor

    //USE THIS TO CHECK RECEPIES WHEN YOU CLICK BREW
    private List<InventoryItem> brewingItems = new List<InventoryItem>();

    [SerializeField] private int balance; // This can be set in the Unity Editor

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
    [SerializeField] private int[] itemCosts; // Assign these in the Unity Editor

    // Maps each InventoryItem to its price
    private Dictionary<InventoryItem, int> itemPrices = new Dictionary<InventoryItem, int>();

    void Start()
    {
        InitializeItemSprites();
        InitializeItemPrices();
        UpdateBal();
        // Example: Initialize inventory with one of each item
        foreach (InventoryItem item in System.Enum.GetValues(typeof(InventoryItem)))
        {
            AddItem(item, 1);
        }
    }
    void UpdateBal()
    {
        balanceText.text = "Balance: $" + balance.ToString();
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
    void InitializeItemPrices()
    {
        // Ensure there's a cost for each item in the enum
        if (itemCosts.Length == Enum.GetValues(typeof(InventoryItem)).Length)
        {
            int i = 0;
            foreach (InventoryItem item in Enum.GetValues(typeof(InventoryItem)))
            {
                itemPrices[item] = itemCosts[i++];
            }
        }
        else
        {
            Debug.LogError("Item costs array length does not match the number of inventory items!");
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
        updateShelf();
    }
    [SerializeField] private GameObject itemBrewPrefab; // Assign in Unity Editor

    public void AddItemToBrewingArea(InventoryItem item)
    {
        Debug.Log("Attempting to add item to brewing area: " + item);

        // Check for an available slot and if the item is in inventory
        int slotIndex = brewingItems.Count;
        if (slotIndex < brewingSlots.Length && inventory[item] > 0)
        {
            // Instantiate the itemBrewPrefab in the slot
            GameObject brewItem = Instantiate(itemBrewPrefab, brewingSlots[slotIndex].transform);

            // Set the proper name
            brewItem.name = item.ToString();

            // Find and set the item name text in the brewing prefab
            Text brewItemNameText = brewItem.transform.Find("ItemNameText")?.GetComponent<Text>();
            if (brewItemNameText != null)
            {
                brewItemNameText.text = item.ToString().Replace("_", " "); // Adjust for enum naming convention if necessary
            }
            else
            {
                Debug.LogWarning("ItemNameText not found in the ItemBrewPrefab");
            }

            // Find and set the item sprite in the brewing prefab
            Image brewItemImage = brewItem.transform.Find("ItemImage")?.GetComponent<Image>();
            if (brewItemImage != null)
            {
                if (itemSprites.ContainsKey(item))
                {
                    brewItemImage.sprite = itemSprites[item];
                }
            }
            else
            {
                Debug.LogWarning("ItemImage not found in the ItemBrewPrefab or no sprite available for the item");
            }

            // Update the list with the item
            brewingItems.Add(item);

            // Remove the item from inventory
            RemoveItem(item, 1);

            // Hook up the remove function
            brewItem.GetComponent<Button>().onClick.AddListener(() => RemoveItemFromBrewingArea(item, brewItem));
        }
    }

    public void RemoveItemFromBrewingArea(InventoryItem item, GameObject brewItem)
    {
        // Add the item back to inventory
        AddItem(item, 1);

        // Remove the item from the brewingItems list
        brewingItems.Remove(item);

        // Remove the prefab from the slot
        Destroy(brewItem);

        // You may want to reorder the items in the brewing slots here
        // and update the brewingItems list to match the new order.
    }

    private void updateShelf()
    {
        UpdateBal();
        // Clear the inventory shelf of any existing children
        foreach (Transform child in inventoryShelf.transform)
        {
            Destroy(child.gameObject);
        }

        // Iterate over each item in the inventory and create a button for it
        foreach (KeyValuePair<InventoryItem, int> entry in inventory)
        {
            // Instantiate a new item prefab as a child of the inventory shelf
            GameObject itemButton = Instantiate(itemPrefab, inventoryShelf.transform);
            itemButton.name = entry.Key.ToString();

            // Assuming itemButton has two children: one for item text and another for cost text
            Text itemNameText = itemButton.transform.Find("ItemNameText").GetComponent<Text>();
            Text itemCostText = itemButton.transform.Find("ItemCostText").GetComponent<Text>();

            // Set the name and quantity text on the item button
            if (itemNameText != null)
            {
                itemNameText.text = $"{entry.Key}\n({entry.Value})"; // e.g., "MorningDew (1)"
            }

            // Set the cost text on the item button
            if (itemCostText != null)
            {
                itemCostText.text = $"${itemPrices[entry.Key]}"; // e.g., "$10"
            }

            // Set the background sprite, assuming there is an Image component
            Image backgroundImage = itemButton.GetComponent<Image>();
            if (backgroundImage != null && itemSprites.ContainsKey(entry.Key))
            {
                backgroundImage.sprite = itemSprites[entry.Key];
            }

            // Get the purchase button, which may be a separate child button to buy more of the item
            Button purchaseButton = itemButton.transform.Find("PurchaseButton").GetComponent<Button>();
            if (purchaseButton != null)
            {
                // Hook up the onClick event to call OnPurchaseItem with the correct item
                purchaseButton.onClick.AddListener(() => OnPurchaseItem(entry.Key));
            }

            // Set button interactability based on quantity
            Button itemButtonComponent = itemButton.GetComponent<Button>();
            if (itemButtonComponent != null)
            {
                itemButtonComponent.interactable = entry.Value > 0;

                // Optionally, change the button color to grey if it's disabled
                Image buttonImage = itemButton.GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = entry.Value > 0 ? Color.white : Color.grey;
                }
            }
            if (itemButtonComponent != null)
            {
                Debug.Log("Adding listener for " + entry.Key);
                itemButtonComponent.onClick.AddListener(() => AddItemToBrewingArea(entry.Key));
            }
            // You might also want to disable the purchaseButton based on the item quantity
            if (purchaseButton != null)
            {
                //purchaseButton.interactable = entry.Value > 0;
            }
        }
    }


    public void OnPurchaseItem(InventoryItem item)
    {
        int itemCost;
        if (itemPrices.TryGetValue(item, out itemCost) && balance >= itemCost)
        {
            balance -= itemCost; // Subtract the cost from the balance
            AddItem(item, 1); // Add one to the item's quantity
        }
        else
        {
            Debug.Log("Not enough balance or item cost not found!");
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
                inventory[item] = 0; // Set quantity to 0 instead of removing the item
            }
            updateShelf();
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
