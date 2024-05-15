using System;
using Component;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float bulletSpeed = 10;
    private Transform _target;

    public void SetTarget(Transform enemyPos)
    {
        _target = enemyPos;
    }
    
    private void Update()
    {
        if (_target != null)
        {
            
            Vector3 direction = _target.position - transform.position;
            direction.Normalize(); 

            
            transform.Translate(direction * bulletSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().Damage(damage);
        Destroy(gameObject);
    }
}
