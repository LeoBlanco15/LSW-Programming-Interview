using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    private Item item;

    public void AddItem(Item addItem)
    {
        item = addItem;

        icon.sprite = item.logo;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        Debug.Log("Cleans the slot");
    }
    public void UseItem()
    {
        if(item != null)
            item.Use();
    }
    public void BuyItem()
    {
        if (item != null)
            ShopUI.instance.interactShop.Buy(item);
    }
}
