using System;
using UnityEngine;

public class SaveUpLevel : MonoBehaviour
{
    [SerializeField] private GameObject block;
    
    private int Open;
    private string key;
    

    private void Start()
    {
        key = gameObject.name;
        block = transform.GetChild(1).gameObject;
        Open = PlayerPrefs.GetInt(key);
        if (Open == 0)
        {
            block.SetActive(true);
        }
        else
        {
            block.SetActive(false);
        }
        
    }
}
