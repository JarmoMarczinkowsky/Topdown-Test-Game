using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZaWarudo : MonoBehaviour
{

    private float waitTime = 0;
    private short hasPressed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.gKey.isPressed)
        {
            if(hasPressed == 0)
            {
                hasPressed = 1;
                StartCoroutine(fuckingWait());
            }

            
        }
        
    }

    IEnumerator fuckingWait()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.localScale += new Vector3(.05f * i, .05f * i, .05f * i);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
