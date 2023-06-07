using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPosition;

    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(0, moveY) * speed;

        if (Keyboard.current.sKey.isPressed) //down
        {
            //rotate sprite to look -45 degrees down
            transform.rotation = Quaternion.Euler(0, 0, -15);
        }
        else if (Keyboard.current.wKey.isPressed)
        {
            transform.rotation = Quaternion.Euler(0, 0, 15);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, shootingPosition.position, transform.rotation);
        }
    }
}
