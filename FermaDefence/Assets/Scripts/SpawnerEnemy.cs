using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private RectTransform[] spawnPosition;
    [SerializeField] private GameObject[] spawnObject;
    [SerializeField] private float delaySpawn;


    private void Start()
    {
        StartCoroutine(Spawner());
    }

    
    



    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            GameObject newEnemy = Instantiate(spawnObject[Random.Range(0, spawnObject.Length)], 
                spawnPosition[Random.Range(0, spawnPosition.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(delaySpawn);
        }

       
    }
}
