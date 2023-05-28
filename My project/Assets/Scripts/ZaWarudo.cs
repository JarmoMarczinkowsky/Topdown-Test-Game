using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ZaWarudo : MonoBehaviour
{
    public Tilemap tilemap;
    public Color myColor = new Color(100, 100, 100, 255);

    private short hasPressed = 0;
    private short loopLength = 50;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.shiftKey.isPressed)
        {
            if(hasPressed == 0)
            {
                hasPressed = 1;
                //change color of sprite
                sprite.color = new Color(0, 0, 0, 255);
                StartCoroutine(fuckingWait(1));
            }
            //else
            //{
            //    hasPressed = 0;
            //    StartCoroutine(fuckingWait(-1));

            //}
        }
        else if (Keyboard.current.shiftKey.wasReleasedThisFrame)
        {
            hasPressed = 0;
            StartCoroutine(fuckingWait(-1));
        }
    }

    void SetTilemapColor(Color color)
    {
        for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++)
        {
            for (int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                TileBase tile = tilemap.GetTile(tilePosition);
                if (tile != null)
                {
                    tilemap.SetTileFlags(tilePosition, TileFlags.None);
                    tilemap.SetColor(tilePosition, color);
                }
            }
        }
    }

    IEnumerator fuckingWait(int reverse)
    {
        SetTilemapColor(myColor);


        for (int i = 0; i < loopLength; i++)
        {
            transform.localScale += new Vector3(.05f * i * reverse, .05f * i * reverse, .05f * i * reverse);

            if (Mathf.Round(loopLength / 2) == i && reverse != -1)
            {
                SetTilemapColor(myColor);
            }

            yield return new WaitForSeconds(0.01f);
        }

        if (reverse == -1)
        {
            sprite.color = new Color(0, 0, 0, 0);
            SetTilemapColor(new Color(255, 255, 255, 255));
        }
    }
}
