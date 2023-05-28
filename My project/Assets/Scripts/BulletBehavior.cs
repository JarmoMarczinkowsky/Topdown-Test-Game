using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletBehavior : MonoBehaviour
{
    public float Speed = 10f;
    public Rigidbody2D rb;

    //public static short hasPressed;

    private float speedModifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;

        //bug
        //new bullets spawn with velocity 0f

    }

    void Update()
    {
        //time slows down for bullets when shift is pressed
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            speedModifier = 0.01f;
        }
        else
        {
            speedModifier = 1f;
        }

        rb.velocity = transform.right * Speed * speedModifier;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Todo: Fix this shit
        //found bug:
        //bullet affected by timne will not destroy itself when hitting wall

        if (hitInfo.name != "BlueBullet(Clone)")
        {
            Debug.Log($"Hit: {hitInfo.name}");

            var enemy = hitInfo.GetComponent<EnemyBehavior>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            Destroy(gameObject);
        }
        
    }
}
