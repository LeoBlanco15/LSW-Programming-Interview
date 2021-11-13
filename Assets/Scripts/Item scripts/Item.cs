using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public ItemSlot type;
    public Sprite logo;
    public int cost;
    private bool equiped;

    public bool Equiped
    {
        get
        {
            return this.equiped;
        }
        set
        {
            this.equiped = value;
        }
    }
    public virtual void Use()
    {
        Debug.Log("Using item");
        if (ShopUI.instance.shopOpen)
            ShopUI.instance.interactShop.Sell(this);
        else
            MainCharacterChothes.instance.ChangeItem(this);
    }
}
public enum ItemSlot
{
    Hood,
    Face,
    Chest,
    Leg,
}
