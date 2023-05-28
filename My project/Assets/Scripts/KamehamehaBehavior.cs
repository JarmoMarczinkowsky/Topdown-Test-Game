using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KamehamehaBehavior : MonoBehaviour
{
    public Transform FireballSize;
    public float SizeModifier = 3f;
    public GameObject MyGameobject;
    public Transform PlayerPosition;

    private float chargeSpeed;
    private Rigidbody2D rb;
    private RigidbodyConstraints2D pos;
    private float speed = 1;
    private bool released = false;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (released)
        {
            return;
        }

        if (Keyboard.current.fKey.isPressed)
        {
            chargeSpeed += Time.deltaTime;
            //Debug.Log(chargeSpeed);

        }
        else if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            if (transform.localScale.x < 0.2f)
            {
                Destroy(gameObject);
            }

            rb = MyGameobject.AddComponent<Rigidbody2D>();
            pos = RigidbodyConstraints2D.FreezeRotation;

            speed = 12 / (chargeSpeed / 2);
            
            rb.mass = chargeSpeed;
            rb.velocity = transform.right * speed;
            
            released = true;
        }

        FireballSize.localScale = new Vector3(chargeSpeed / SizeModifier * 1.1f, chargeSpeed / SizeModifier * 1.1f, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Player")
        {
            Destroy(gameObject);

            if(collision.collider.tag == "Enemy")
            {
                collision.collider.GetComponent<EnemyBehavior>().TakeDamage(rb.mass * 1.5f);
                Debug.Log($"Hit enemy with {rb.mass} mass");
            }
        }
    }
}
