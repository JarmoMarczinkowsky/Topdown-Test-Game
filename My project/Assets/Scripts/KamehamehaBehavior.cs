using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KamehamehaBehavior : MonoBehaviour
{
    public Transform FireballSize;
    public float SizeModifier = 3f;

    private float chargeSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            chargeSpeed += Time.deltaTime;
            Debug.Log(chargeSpeed);

        }
        else if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            Debug.Log("Released");
        }
        else
        {
            chargeSpeed = 0;
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        FireballSize.localScale = new Vector3(chargeSpeed / SizeModifier, chargeSpeed / SizeModifier, 0);

    }
}
