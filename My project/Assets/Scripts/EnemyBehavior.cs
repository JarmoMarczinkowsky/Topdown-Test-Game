using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float Hitpoints; 
    public float MaxHitPoints = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitPoints;
    }

    public void TakeDamage(float damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
