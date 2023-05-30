using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    public GameObject MyEnemy;
    public float TimeToWait = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitTime(TimeToWait, MyEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitTime(float time, GameObject swarmPrefab)
    {
        yield return new WaitForSeconds(time);
        Instantiate(swarmPrefab, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);

        if (Keyboard.current.shiftKey.isPressed)
        {
            StartCoroutine(WaitTime(TimeToWait / 0.1f, swarmPrefab));
        }
        else
        {
            StartCoroutine(WaitTime(TimeToWait, swarmPrefab));
        }
    }
}
