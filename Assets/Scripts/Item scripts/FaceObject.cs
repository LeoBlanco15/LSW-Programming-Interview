using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Inventory/Face")]
public class FaceObject : Item
{
    public Sprite face;

    public static FaceObject CreateFace(Face sprite, int auxCost)
    {
        FaceObject auxFace = ScriptableObject.CreateInstance<FaceObject>();

        auxFace.cost = auxCost;
        auxFace.face = sprite.sprite.sprite;

        auxFace.type = ItemSlot.Face;
        auxFace.logo = sprite.sprite.sprite;
        auxFace.Equiped = true;
        return auxFace;
    }

    public void SwitchFace(ref SpriteRenderer sprite)
    {
        sprite.sprite = face;
    }
}
