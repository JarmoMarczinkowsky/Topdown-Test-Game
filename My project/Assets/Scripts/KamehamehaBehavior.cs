using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KamehamehaBehavior : MonoBehaviour
{
    public Transform FireballSize;
    public float SizeModifier = 3f;
    public float SizeFactor = 1.1f;
    public GameObject MyGameobject;

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

        FireballSize.localScale = new Vector3(chargeSpeed / SizeModifier * SizeFactor, chargeSpeed / SizeModifier * SizeFactor, 0);

        if (Keyboard.current.shiftKey.isPressed)
        {
            rb.velocity = transform.right * speed * 0.1f;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Player")
        {
            Destroy(gameObject);

            if(collision.collider.tag == "Enemy")
            {
                collision.collider.GetComponent<EnemyBehavior>().TakeDamage(transform.localScale.x * 3f);
                //enemy thats hit doesnt move
                collision.collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                collision.collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                collision.collider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                //collision.collider.GetComponent<Rigidbody2D>().velocity = transform.right * speed * rb.mass;
                //rb.velocity = transform.right * speed * rb.mass;
                Debug.Log($"Hit enemy with {transform.localScale.x * 3f} damage");
            }
        }
    }
}
