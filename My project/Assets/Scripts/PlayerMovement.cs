using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

        if(Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 180, 0);
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            transform.Rotate(0, 0, 0);
        }
            //create a bullet
        
    }
}
