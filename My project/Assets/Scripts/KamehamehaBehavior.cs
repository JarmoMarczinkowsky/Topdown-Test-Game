using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KamehamehaBehavior : MonoBehaviour
{
    public Transform FireballSize;
    public float SizeModifier = 3f;
    public float SizeFactor = 1.1f;
    public GameObject FireballPrefab;

    private Vector3 ShootPosition;
    private SpriteRenderer mySpriteRenderer;
    private float chargeSpeed;
    private Rigidbody2D rb;
    private RigidbodyConstraints2D pos;
    private float speed = 1;
    private bool released = false;
    private float radius = 0;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        ShootPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        radius = mySpriteRenderer.bounds.extents.x;
        Debug.Log($"Radius is: {radius}");


        if (released)
        {
            return;
        }

        if (Keyboard.current.fKey.isPressed)
        {
            chargeSpeed += Time.deltaTime;

            //if sprite player looks to the left


            transform.position = new Vector3(ShootPosition.x + radius, ShootPosition.y, 0);

            //Debug.Log(chargeSpeed);

        }
        else if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            if (transform.localScale.x < 0.2f)
            {
                Destroy(gameObject);
            }

            rb = FireballPrefab.AddComponent<Rigidbody2D>();
            pos = RigidbodyConstraints2D.FreezeRotation;

            speed = 12 / (chargeSpeed / 2);
            
            rb.mass = chargeSpeed;
            rb.velocity = transform.right * speed;
            
            released = true;
        }

        FireballSize.localScale = new Vector3(chargeSpeed / SizeModifier * SizeFactor, chargeSpeed / SizeModifier * SizeFactor, 0);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Player")
        {
            Destroy(gameObject);

            if(collision.collider.tag == "Enemy")
            {
                collision.collider.GetComponent<EnemyBehavior>().TakeDamage(transform.localScale.x * 3f);
                collision.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                Debug.Log($"Hit enemy with {transform.localScale.x * 3f} damage");
            }
        }
    }
}
