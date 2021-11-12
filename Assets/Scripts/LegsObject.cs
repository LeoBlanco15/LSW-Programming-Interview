using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Inventory/Legs")]
public class LegsObject : ScriptableObject
{
    public Sprite legL;
    public Sprite legR;
    public Sprite bootL;
    public Sprite bootR;
    
    public LegsObject(Legs legs)
    {
        legL = legs.legL.sprite;
        legR = legs.legR.sprite;
        bootL = legs.bootL.sprite;
        bootR = legs.bootR.sprite;
    }
}
