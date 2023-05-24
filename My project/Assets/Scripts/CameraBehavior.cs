using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform PlayerTransform;
    public float OffsetX;
    public float OffsetY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(PlayerTransform.position.x + OffsetX, PlayerTransform.position.y + OffsetY);
    }
}
