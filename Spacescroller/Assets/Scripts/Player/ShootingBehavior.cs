using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move asset to the right
        rb.velocity = new Vector2(2 * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Hit {collision.gameObject.name}");
        
        var enemy = collision.collider.GetComponent<AsteroidBehavior>();
        if (enemy != null)
        {
            Debug.Log("Hit enemy");
            enemy.TakeHit(1);            
        }


        Destroy(gameObject);
    }
}
