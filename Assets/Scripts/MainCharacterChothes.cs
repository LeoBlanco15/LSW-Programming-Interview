using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterChothes : MonoBehaviour
{
    public SpriteRenderer hood;
    public SpriteRenderer face;
    public Chest chest;
    public Legs legs;

    private int currentHood;
    private int currentFace;
    private int currentChest;
    private int currentLegs;
    void Start()
    {
        currentHood = 0;
        currentFace = 0;
        currentChest = 0;
        currentLegs = 0;
        Inventory.instance.hoods.Add(hood.sprite);
        Inventory.instance.faces.Add(face.sprite);
        Inventory.instance.chests.Add(new ChestObject(chest));
        Inventory.instance.legs.Add(new LegsObject(legs));
    }

    private void ChangeHood(int indexToChange)
    {
        hood.sprite = Inventory.instance.hoods[indexToChange];
    }
    private void ChangeFace(int indexToChange)
    {
        face.sprite = Inventory.instance.faces[indexToChange];
    }
    /// <summary>
    /// Checks the hood index and then changes it
    /// </summary>
    /// <param name="foward"></param>
    public void UpdateHood(bool foward) //it is called from the button event
    {
        ChangeHood(Count(foward, ref currentHood, Inventory.instance.hoods.Count));
    }
    /// <summary>
    /// Checks the face index and then changes it
    /// </summary>
    /// <param name="foward"></param>
    public void UpdateFace(bool foward) //it is called from the button event
    {
        ChangeFace(Count(foward, ref currentFace, Inventory.instance.faces.Count));
    }
    public void UpdateChest(bool foward) //it is called from the button event
    {
        chest.SwitchChest(Inventory.instance.chests[Count(foward, ref currentChest, Inventory.instance.chests.Count)]);
    }
    public void UpdateLegs(bool foward) //it is called from the button event
    {
        legs.SwitchLegs(Inventory.instance.legs[Count(foward, ref currentLegs, Inventory.instance.legs.Count)]);
    }

    /// <summary>
    /// Calculates the index that should be setted on the character, also updates the counter
    /// </summary>
    /// <param name="foward"></param>
    /// <param name="counter"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    public int Count(bool foward, ref int counter, int limit) 
    {
        if (foward)
        {
            counter++;
            if (counter >= limit)
            {
                counter = 0;
            }
        }
        else if (!foward)
        {
            counter--;
            if (counter < 0)
            {
                counter = limit - 1;
            }
        }
        return counter;
    }
}
