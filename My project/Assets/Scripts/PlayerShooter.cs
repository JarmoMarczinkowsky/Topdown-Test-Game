using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public GameObject fireballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Created bullet");
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }

        if(Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("Created fireball");
            Instantiate(fireballPrefab, shootingPoint.position, transform.rotation);
        }
    }
}
