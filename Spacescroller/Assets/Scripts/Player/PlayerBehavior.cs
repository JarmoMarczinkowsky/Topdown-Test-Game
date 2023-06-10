using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private Transform asteroidPosition;

    private int asteroidCount;

    private float timePassed;
    private float spacePress;

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

        if (Keyboard.current.spaceKey.isPressed)
        {
            spacePress += Time.deltaTime;
            if (spacePress >= 0.4f)
            {
                Instantiate(bulletPrefab, shootingPosition.position, transform.rotation);
                spacePress = 0f;
            }
        }
        //else if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    Instantiate(bulletPrefab, shootingPosition.position, transform.rotation);
        //}

        
        timePassed += Time.deltaTime;
        if (timePassed >= 5f)
        {

            Instantiate(asteroidPrefab, new Vector2(asteroidPosition.position.x, Random.Range(asteroidPosition.position.y - 4.5f, asteroidPosition.position.y + 5)), Quaternion.identity);
            timePassed = 0f;
            //set speedfactor of asteroidbehavior
            asteroidCount++;
            asteroidPrefab.GetComponent<AsteroidBehavior>().speedFactor = 1 + (asteroidCount / 10);
            //Debug.Log($"Speedfactor: {1 + (asteroidCount / 5)}");
        }
    }
}
