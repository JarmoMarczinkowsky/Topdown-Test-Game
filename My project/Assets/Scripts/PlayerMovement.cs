using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX, moveY) * Speed;

        if (moveX < 0)
        {
            // Moving left
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (moveX > 0)
        {
            // Moving right
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        
    }
}
