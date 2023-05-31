using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehavior : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer EyeColor;
    public float speed;
    public float rotationModifier;

    private int bumpCount;
    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            bumpCount++;
        }

        if(bumpCount == 1)
        {
            EyeColor.color = Color.red;
        }
        else if(bumpCount == 2)
        {
            EyeColor.color = new Color(0, 141, 154, 255);
            bumpCount = 0;
        }
    }
}
