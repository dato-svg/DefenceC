using System;
using System.Collections;
using Component;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int bombDamage = 15;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        StartCoroutine(ActivatorBomb(other));
    }


    private IEnumerator ActivatorBomb(Collider2D other1)
    {
        yield return new WaitForSeconds(1);
        if (other1.gameObject.GetComponent<Health>() != null)
        {
            other1.gameObject.GetComponent<Health>().Damage(bombDamage);
            _source.Play();
            yield return new WaitForSeconds(0.2f);
        }
        
        Destroy(gameObject);
       
    }
}

