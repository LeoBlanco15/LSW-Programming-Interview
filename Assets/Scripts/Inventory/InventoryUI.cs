using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemParents;

    private Inventory inventory;
    private InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.inventoryChange += UpdateUI;
        
    }
    private void OnEnable()
    {
        slots = itemParents.GetComponentsInChildren<InventorySlot>();
        
        
    }
    public void UpdateShop()
    {
        
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("Entre");
            if (i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
                Debug.Log("se agrega item");
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
