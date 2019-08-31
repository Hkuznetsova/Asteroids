using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnObjects;
    [SerializeField] int objectCount;
    [SerializeField] float spawnWaitTime;
    [SerializeField] float startWaitTime;
    [SerializeField] float waveWaitTime;

    private Vector3 spawnVector;
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        spawnVector = new Vector3(min.x, max.x, max.y);
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWaitTime);
        while (true)
        {
            for (int i = 0; i < objectCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(spawnVector.x, spawnVector.y), spawnVector.z);
                Quaternion spawnRotation = Quaternion.identity;
                int RandobInt = Random.Range(0, SpawnObjects.Length);
                Instantiate(SpawnObjects[RandobInt], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWaitTime);
            }
            yield return new WaitForSeconds(waveWaitTime);
        }
    }
}
