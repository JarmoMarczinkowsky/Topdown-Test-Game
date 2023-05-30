using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float Hitpoints; 
    public float MaxHitPoints = 10f;
    public float DamageVisibleTime = .1f;

    private SpriteRenderer spriteColor;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitPoints;
        spriteColor = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        Hitpoints -= damage;
        spriteColor.color = Color.red;

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(WaitTime(DamageVisibleTime));
    }

    IEnumerator WaitTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        spriteColor.color = Color.white;
    }
    
}
