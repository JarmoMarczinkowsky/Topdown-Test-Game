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
        yield return new WaitForSeconds(20);

        for (int i = 0; i < 5; i++)
        {
            Instantiate(swarmPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
            Debug.Log($"Spam {i}");
            
            yield return new WaitForSeconds(time);
        }

    }
}
