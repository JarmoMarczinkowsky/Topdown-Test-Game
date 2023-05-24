using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletBehavior : MonoBehaviour
{
    public float Speed = 10f;
    public Rigidbody2D rb;

    private short hasPressed = 0;
    private float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;

    }

    void Update()
    {

        

        //make existing bullets slower. New bullets will spawn with full speed;
        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            if(hasPressed == 0)
            {
                hasPressed = 1;
                speedModifier = 1;
            }
            else
            {
                hasPressed = 0;
                speedModifier = 0.01f;
            }

        }

        rb.velocity = transform.right * Speed * speedModifier;

        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log($"Hit: {hitInfo.name}");
        Destroy(gameObject);
    }
}
