using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private float spawnBulletDelay;
    private GameObject currentEnemy;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    private bool isFiring = false;


    private void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90);
    }

    private void Update()
    {
       
        if (enemiesInRange.Count > 0 && !isFiring)
        {
            currentEnemy = GetNearestEnemy();
            if (currentEnemy != null)
            {
                StartCoroutine(SpawnBullets());
            }
        }
    }

    private GameObject GetNearestEnemy()
    {
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    private IEnumerator SpawnBullets()
    {
        isFiring = true;
        while (currentEnemy != null)
        {
            if (currentEnemy != null)
            {
                
               
            
              
                GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
                newBullet.GetComponent<Bullet>().SetTarget(currentEnemy.transform);
                yield return new WaitForSeconds(spawnBulletDelay);
            }
        
            isFiring = false;
        
            break;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MoveEnemy>()!= null)
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<MoveEnemy>()!= null)
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

   
}
