using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shop;

    public List<Item> itemsOnSale;
    public delegate void OnShopUpdate();
    public OnShopUpdate shopUpdate;

    private bool isInside;

    private void Start()
    {
        foreach (Item item in itemsOnSale)
        {
            item.Equiped = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isInside && InputManager.GetInteract() && !InputManager.isPaused)
        {
            Interact(true);
        }
        else if (isInside && InputManager.GetInteract() && InputManager.isPaused)
        {
            Interact(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = true;
        }
        ShopUI.instance.interactShop = this;
        ShopUI.instance.SetUpShop();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = false;
        }
        ShopUI.instance.interactShop = null;
        shop.SetActive(false);
        Inventory.instance.ToggleInventory(false);
    }
    public void Interact(bool toggle)
    {
        Debug.Log("Interacted");
        shop.SetActive(toggle);
        ShopUI.instance.shopOpen = toggle;
        Inventory.instance.ToggleInventory(toggle);
    }
    public void Buy(Item item)
    {
        if (Inventory.instance.Pay(item.cost))
        {
            Inventory.instance.AddItem(item);
            itemsOnSale.Remove(item);
            shopUpdate.Invoke();
        }
    }
    public void Sell(Item item)
    {
        if (!item.Equiped)
        {
        Inventory.instance.RemoveItem(item);
        itemsOnSale.Add(item);
        Inventory.instance.GetPayed(item.cost);
        shopUpdate.Invoke();
        }
        else
        {
            Debug.Log("Item equiped");
        }
    }
}
