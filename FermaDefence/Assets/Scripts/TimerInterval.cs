using System;
using System.Collections;
using System.Linq;
using Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerInterval : MonoBehaviour
{
   [SerializeField] private float totalTime = 60f;
   [SerializeField] private Image image;
   [SerializeField] private GameObject panelWin;
   [SerializeField] private GameObject spawnerEnemy;
   [SerializeField] [Space(15)] private int Level;
   private MoveEnemy[] _moveEnemies;
   
   private Coroutine _coroutine;
   private void Start()
   {
      _moveEnemies = new MoveEnemy[50];
      image = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
      _coroutine = StartCoroutine(UpdateTimer());
   }
   
   
   private IEnumerator UpdateTimer()
   {
      float elapsedTime = 0f;
      while (elapsedTime < totalTime)
      {
         elapsedTime += Time.deltaTime;
         float fillAmount = Mathf.Clamp01(elapsedTime / totalTime); 

         image.fillAmount = fillAmount;

         yield return null;
       
      }
     
      GameWin();
      
   }

   private void GameWin()
   {
      spawnerEnemy.SetActive(false);
      panelWin.SetActive(true);
      panelWin.transform.GetChild(1).gameObject.SetActive(false);
      panelWin.transform.GetChild(3).gameObject.SetActive(false);
      
      PlayerPrefs.SetInt("Image"+Level,1);
      
      _moveEnemies = FindObjectsOfType<MoveEnemy>();
      
      
      foreach (var enemy in _moveEnemies)
      {
         Destroy(enemy.gameObject);
      }
   }
   
   public void GameLoose()
   {
      spawnerEnemy.SetActive(false);
      panelWin.SetActive(true);
      panelWin.transform.GetChild(0).gameObject.SetActive(false);
      panelWin.transform.GetChild(4).gameObject.SetActive(false);
      StopCoroutine(_coroutine);
      image.fillAmount = 0;
      _moveEnemies = FindObjectsOfType<MoveEnemy>();
      
      
      foreach (var enemy in _moveEnemies)
      {
         Destroy(enemy.gameObject);
      }
   }
}
