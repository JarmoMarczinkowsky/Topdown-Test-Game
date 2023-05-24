using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZaWarudo : MonoBehaviour
{

    private float waitTime = 0;
    private short hasPressed = 0;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.gKey.wasReleasedThisFrame)
        {
            if(hasPressed == 0)
            {
                hasPressed = 1;
                //change color of sprite
                sprite.color = new Color(0,0,0, 255);

                StartCoroutine(fuckingWait(1));
            }
            else
            {
                hasPressed = 0;
                StartCoroutine(fuckingWait(-1));
                Debug.Log("Reached here");

            }


        }
        
    }

    IEnumerator fuckingWait(int reverse)
    {
        for (int i = 0; i < 100; i++)
        {
            transform.localScale += new Vector3(.05f * i * reverse, .05f * i * reverse, .05f * i * reverse);
            yield return new WaitForSeconds(0.01f);
        }

        if (reverse == -1)
        {
            sprite.color = new Color(0, 0, 0, 0);

        }
    }
}
