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
    [SerializeField] private Color hitColor;
    [SerializeField] private HealthBarBehavior Healthbar;
    private float health;

    private SpriteRenderer myColor;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float getRandom = Random.Range(1f, 10f);
        transform.localScale = new Vector2(getRandom, getRandom);

        //health is relative to the size of the asteroid
        //the bigger the asteroid, the more health it has
        health = Mathf.Round(transform.localScale.x * 3);

        hitpoints = health;

        //mass is relative to the size of the asteroid
        //the bigger the asteroid, the more mass it has
        rb.mass = Mathf.Round(transform.localScale.x * 3 * speedFactor);

        myText.text = Mathf.Round(hitpoints).ToString();

        myColor = GetComponent<SpriteRenderer>();

        Healthbar.SetHealth(hitpoints, health);


    }

    // Update is called once per frame
    void Update()
    {
        //speed is -10
        //speed is relative to the size of the asteroid
        //the bigger the asteroid, the slower it moves
        if (rb != null)
        {
            rb.velocity = new Vector2((-speed / transform.localScale.x) * speedFactor, 0);
        }
        //rb.velocity = new Vector2(-2 * speed, 0);
    }

    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        Healthbar.SetHealth(hitpoints, health);

        myText.text = Mathf.Round(hitpoints).ToString();

        myColor.color = hitColor;


        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(waitTime(.1f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //deletes asteroid if it hits the fail square
        if (collision.collider.tag == "Border")
        {
            Debug.Log("Asteroid hit a border");
            Destroy(gameObject);
        }
    }

    private IEnumerator waitTime(float wait)
    {
        yield return new WaitForSeconds(wait);
        myColor.color = Color.white;
    }
}
