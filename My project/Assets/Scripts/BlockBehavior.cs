using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public Collider2D container; 
    private SpriteRenderer spriteColor;
    private Collider2D myBlocky;
    // Start is called before the first frame update
    void Start()
    {
        spriteColor = GetComponent<SpriteRenderer>();
        myBlocky = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (container.bounds.Contains(myBlocky.bounds.min) && container.bounds.Contains(myBlocky.bounds.max))
        {
            spriteColor.color = Color.blue;
            Debug.Log("Fully within");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "FinishLine")
        //{
        //    Debug.Log("Hit the finish line!");
        //}

        
    }
}
