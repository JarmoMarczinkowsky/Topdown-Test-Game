using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletBehavior : MonoBehaviour
{
    public float Speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;  
    }

    void Update()
    {
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            rb.velocity = transform.right * Speed * 0.01f;
        }
        else
        {
            rb.velocity = transform.right * Speed * 1;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log($"Hit: {hitInfo.name}");
        Destroy(gameObject);
    }
}
