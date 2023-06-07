using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float getRandom = Random.Range(1f, 7f);
        transform.localScale = new Vector2(getRandom, getRandom);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-2 * speed, 0);
    }
}
