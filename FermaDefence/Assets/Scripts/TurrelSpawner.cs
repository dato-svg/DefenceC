using System;
using UI;
using Unity.Mathematics;
using UnityEngine;

public class TurrelSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject spawnTurrets;
    [SerializeField] private GameObject[] turretsPoint;
    [SerializeField] private int priceTurret = 100;
    private void Start()
    {
        turretsPoint = new GameObject[transform.childCount];
        for (int i = 0; i < turretsPoint.Length; i++)
        {
            turretsPoint[i] = transform.GetChild(i).gameObject;
        }
    }

    
    public void Spawn()
    {
        if (PlayerStats.Coin >= priceTurret)
        {
            for (int i = 0; i < turretsPoint.Length; i++)
            {
                if (turretsPoint[i].GetComponentInChildren<Drag>() == null)
                {
                    PlayerStats.AddCoin(-priceTurret);
                    GameObject turret = Instantiate(spawnTurrets, transform.position, quaternion.identity);
                    turret.transform.SetParent(turretsPoint[i].transform);
                    turret.transform.localScale = new Vector3(0.7f,1,1);
                    turret.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    return;
              
                }
            }
        }
        
    }
}
