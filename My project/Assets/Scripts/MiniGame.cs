using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGame : MonoBehaviour
{
    [SerializeField]
    private Collider2D square;

    [SerializeField]
    private Collider2D triangle;

    [SerializeField]
    private float spinSpeed = 0.01f;
    private bool spinning = true;
    private bool holding = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!spinning)
        {
            return;
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            if (square.bounds.Contains(triangle.bounds.min) && square.bounds.Contains(triangle.bounds.max) && !holding)
            {
                spinning = false;
                Debug.Log("Fully within");
            }
            else
            {
                holding = true;
                Debug.Log("Missed");
            }
        }
        else if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            holding = false;
        }

        

        transform.Rotate(0, 0, -1 * spinSpeed);
    }
}
