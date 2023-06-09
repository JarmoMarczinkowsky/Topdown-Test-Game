using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    [SerializeField] public float speedFactor = 1f;
    [SerializeField] public float speed = 5f;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float hitpoints;
    [SerializeField] private TextMeshPro myText;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float getRandom = Random.Range(1f, 10f);
        transform.localScale = new Vector2(getRandom, getRandom);

        //health is relative to the size of the asteroid
        //the bigger the asteroid, the more health it has
        float health = Mathf.Round(transform.localScale.x * 3);

        hitpoints = health;

        //mass is relative to the size of the asteroid
        //the bigger the asteroid, the more mass it has
        rb.mass = Mathf.Round(transform.localScale.x * 3);

        myText.text = Mathf.Round(hitpoints).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //speed is -10
        //speed is relative to the size of the asteroid
        //the bigger the asteroid, the slower it moves
        if (rb != null)
        {
            rb.velocity = new Vector2(-speed / transform.localScale.x, 0);
        }
        //rb.velocity = new Vector2(-2 * speed, 0);
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        myText.text = Mathf.Round(hitpoints).ToString();

        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //deletes asteroid if it hits the fail square
        if (collision.collider.name == "FailAsteroid")
        {
            Destroy(gameObject);
        }
    }
}
