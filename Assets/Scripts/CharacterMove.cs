using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public GameObject followCamara;
    public Vector3 camaraOffSet;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //player input goes here
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        //physics are managed here
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * speed);
    }
    private void LateUpdate()
    {
        //for camara follow
        followCamara.transform.position = gameObject.transform.position + camaraOffSet;

    }
}
