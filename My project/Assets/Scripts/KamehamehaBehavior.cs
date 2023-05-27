using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KamehamehaBehavior : MonoBehaviour
{
    public Transform FireballSize;
    public float SizeModifier = 0.001f;
    private int chargeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            chargeSpeed++;
            transform.localScale = new Vector3(chargeSpeed * (chargeSpeed / 40) * SizeModifier, chargeSpeed * (chargeSpeed / 40) * SizeModifier, chargeSpeed * (chargeSpeed / 40) * SizeModifier);

        }
        else
        {
            chargeSpeed = 0;
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

    }
}
