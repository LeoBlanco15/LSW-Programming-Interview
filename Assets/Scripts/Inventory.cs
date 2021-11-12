using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Sprite> hoods;
    public List<Sprite> faces;
    public List<ChestObject> chests;

    private int currentHood;
    private int currentFace;
    private MainCharacterChothes clothes;
    private int gold;
    // Start is called before the first frame update
    void Start()
    {
        clothes = gameObject.GetComponent<MainCharacterChothes>();
        hoods.Add(clothes.hood.sprite);
        faces.Add(clothes.face.sprite);
        chests.Add(new ChestObject(clothes.chest));
        currentHood = 0;
        currentFace = 0;
        gold = 100;
    }

    private void ChangeHood(int indexToChange)
    {
        clothes.hood.sprite = hoods[indexToChange];
    }
    private void ChangeFace(int indexToChange)
    {
        clothes.face.sprite = faces[indexToChange];
    }
    /// <summary>
    /// Checks the hood index and then changes it
    /// </summary>
    /// <param name="foward"></param>
    public void UpdateHood(bool foward) //it is called from the button event
    {
        if (foward)
        {
            currentHood++;
            if (currentHood >= hoods.Count)
            {
                currentHood = 0;
            }
        }
        else if (!foward)
        {
            currentHood--;
            if (currentHood < 0)
            {
                currentHood = hoods.Count - 1;
            }
        }
        ChangeHood(currentHood);
    }
    /// <summary>
    /// Checks the face index and then changes it
    /// </summary>
    /// <param name="foward"></param>
    public void UpdateFace(bool foward) //it is called from the button event
    {
        if (foward)
        {
            currentFace++;
            if (currentFace >= faces.Count)
            {
                currentFace = 0;
            }
        }
        else if (!foward)
        {
            currentFace--;
            if (currentFace < 0)
            {
                currentFace = faces.Count - 1;
            }
        }
        ChangeFace(currentFace);
    }
}
