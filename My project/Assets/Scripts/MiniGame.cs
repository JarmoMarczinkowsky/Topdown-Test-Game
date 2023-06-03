using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGame : MonoBehaviour
{
    [SerializeField]
    private Collider2D square;

    [SerializeField] private SpriteRenderer lineSprite;

    [SerializeField]
    private Collider2D triangle;

    [SerializeField]
    private float waitTime;

    [SerializeField]
    private float spinSpeed = 0.01f;
    private bool spinning = true;
    private float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitTime(waitTime));
    }

    private void Spinning()
    {

        //check if triangle is within square and change color of line
        ChangeColor();

        //if triangle is within square and space is pressed, stop spinning
        if (Keyboard.current.spaceKey.wasPressedThisFrame && square.bounds.Contains(triangle.bounds.min) && square.bounds.Contains(triangle.bounds.max))
        {
            spinning = false;
        }

        if (spinning && counter <= 360)
        {
            transform.Rotate(0, 0, -1 * spinSpeed);
            counter += spinSpeed;
        }

    }

    private void ChangeColor()
    {
        if (square.bounds.Contains(triangle.bounds.min) && square.bounds.Contains(triangle.bounds.max))
        {
            lineSprite.color = Color.green;
        }
        else
        {
            lineSprite.color = Color.red;
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        Spinning();
    }
}
