using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal") * speed;
        float dirY = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector2(dirX, dirY);
    }
}
