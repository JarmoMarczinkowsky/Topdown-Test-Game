using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public Transform shootingPoint;
    public Transform fireballPoint;
    public GameObject bulletPrefab;
    public GameObject fireballPrefab;
    public TextMeshPro AmmoScore;
    public int BulletCount;

    // Start is called before the first frame update
    void Start()
    {
        AmmoScore.text = BulletCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        AmmoScore.text = BulletCount.ToString();

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

    public void AddBullet(int bulletCount)
    {
        BulletCount += bulletCount;
    }
}
