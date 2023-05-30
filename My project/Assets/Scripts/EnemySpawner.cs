using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject MyEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitTime(5, MyEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitTime(float time, GameObject swarmPrefab)
    {
        yield return new WaitForSeconds(time);
        Instantiate(swarmPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
        StartCoroutine(WaitTime(5, swarmPrefab));
    }
}
