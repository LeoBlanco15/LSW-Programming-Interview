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
    public List<Sprite> hoods;
    public List<Sprite> faces;
    public List<ChestObject> chests;
    public List<LegsObject> legs;

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

    private void ToggleInventory(bool toggle)
    {
        InputManager.isPaused = toggle;
        inventoryUI.SetActive(toggle);
    }
}
