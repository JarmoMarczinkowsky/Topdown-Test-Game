using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public Transform shootingPoint;
    public Transform fireballPoint;
    public GameObject bulletPrefab;
    public GameObject fireballPrefab;
    public static int BulletCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && BulletCount > 0)
        {
            Debug.Log("Created bullet");
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            BulletCount--;
        }

        if(Keyboard.current.fKey.wasPressedThisFrame)
        {
            Debug.Log("Created fireball");
            Instantiate(fireballPrefab, fireballPoint.position, transform.rotation);
        }
    }
}
