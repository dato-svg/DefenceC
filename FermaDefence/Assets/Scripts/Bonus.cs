using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
   [SerializeField] private int countCoinGive;
   [SerializeField] private LayerMask bonus;
   [SerializeField] private AudioClip clip; 
   private AudioSource source;
   private void Start()
   {
      Destroy(gameObject,8);
      source = GameObject.Find("BonusSourse").GetComponent<AudioSource>();

   }
   
   private void Update()
   {
      
      if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
      {
      
         Vector2 touchPosition = Input.mousePosition;
         if (Input.touchCount > 0)
         {
            touchPosition = Input.GetTouch(0).position;
         }
         
         Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
         RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero,1000,bonus);

         if (hit.collider != null)
         {
      
            if (hit.collider.GetComponent<Bonus>() != null)
            {
               if (hit.collider.gameObject == gameObject)
               {
                  PlayerStats.AddCoin(countCoinGive);
                  Destroy(gameObject);
                  source.PlayOneShot(clip);
               }
              
            }
         }
      }
   }
   
}
