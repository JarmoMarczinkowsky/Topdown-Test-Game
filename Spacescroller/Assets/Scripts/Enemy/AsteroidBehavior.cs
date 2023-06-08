using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float hitpoints;
    [SerializeField] private TextMeshPro myText;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float getRandom = Random.Range(1f, 7f);
        transform.localScale = new Vector2(getRandom, getRandom);
        
        float health = transform.localScale.x * 1.5f;
        Debug.Log(health);
        hitpoints = health;

        myText.text = Mathf.Round(hitpoints).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-2 * speed, 0);
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
}
