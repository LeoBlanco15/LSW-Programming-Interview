using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    private bool isInside;

    // Update is called once per frame
    void Update()
    {
        if (isInside && Input.GetButtonDown("Interact"))
        {
            Interact();
        }
    }

    public void Interact()
    {
        Debug.Log("Interacted");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = false;
        }
    }
}
