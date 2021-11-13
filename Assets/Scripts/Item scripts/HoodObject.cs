using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Inventory/Hood")]
public class HoodObject : Item
{
    public Sprite hood;
    public static HoodObject CreateHood(Hood sprite, int cost)
    {
        HoodObject auxHood = ScriptableObject.CreateInstance<HoodObject>();
        auxHood.cost = cost;
        auxHood.hood = sprite.sprite.sprite;
        auxHood.logo = sprite.sprite.sprite;
        auxHood.type = ItemSlot.Hood;
        auxHood.Equiped = true;
        return auxHood;
    }
}
