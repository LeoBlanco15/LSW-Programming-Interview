using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject inventoryUI;
    public List<Item> itemList;

    public delegate void OnInventoryChange();
    public OnInventoryChange inventoryChange;

    private int gold;
    // Start is called before the first frame update
    void Start()
    {
        ToggleInventory(false);
        gold = 100;
    }

    private void Update()
    {
        if (!InputManager.isPaused && InputManager.GetInventory())
        {
            ToggleInventory(true);
        }
        else if (InputManager.isPaused && InputManager.GetInventory())
        {
            ToggleInventory(false);
        }
    }
    /// <summary>
    /// Checks the item type and adds it to the corresponding list
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        itemList.Add(item);
        inventoryChange.Invoke();
    }
    public bool Pay(int amount)
    {
        if (amount <= gold)
        {
            gold -= amount;
            return true;
        }
        else
        {
            Debug.Log("not enough money");
            return false;
        }
    }
    public void GetPayed(int amount)
    {
        gold += amount;
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        inventoryChange.Invoke();
    }
    public void ToggleInventory(bool toggle)
    {
        InputManager.isPaused = toggle;
        inventoryUI.SetActive(toggle);
    }
    public void UnEquipAll(ItemSlot itemSlot)
    {
        foreach (Item item in itemList)
        {
            if (item.type == itemSlot)
            {
                item.Equiped = false;
            }
        }
    }
}
