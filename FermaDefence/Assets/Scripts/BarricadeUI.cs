using System;
using Component;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarricadeUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI currentXP;
    [SerializeField] private TextMeshProUGUI maxXP;
    
    private Barricade _barricade;
    private Animator _animator;
    private int _currentIndex;
    private static readonly int Show1 = Animator.StringToHash("show");
    private AudioSource _source;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _barricade = FindObjectOfType<Barricade>();
        _source = GetComponent<AudioSource>();
        ShowText();
    }

    public void Show(bool show)
    {
        _animator.SetBool(Show1,show);
    }

    public void FixedBarricade()
    {
        if (PlayerStats.Coin >= 50)
        {
             PlayerStats.AddCoin(-50);
            _barricade.GetComponent<Health>()._currentHealth = _barricade.GetComponent<Health>().maxHealth;
            _source.Play();
        }
        
       
    }

    public void UpdateBarricade()
    {
        if (PlayerStats.Coin >= 150)
        {
            PlayerStats.AddCoin(-150);
            _source.Play();
            _barricade.GetComponent<Health>().maxHealth += 100;
            _barricade.GetComponent<Health>()._currentHealth = _barricade.GetComponent<Health>().maxHealth;
            _barricade.GetComponent<Image>().sprite  = _barricade.BarriсadeSprite[_currentIndex];
            _currentIndex++;
            if (_currentIndex >= _barricade.BarriсadeSprite.Length)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
            }
            
            
            ShowText();
        }
       
    }

    private void FixedUpdate()
    {
        ShowText();
    }

    private void ShowText()
    {
        currentXP.text = _barricade.GetComponent<Health>()._currentHealth.ToString();
        maxXP.text = _barricade.GetComponent<Health>().maxHealth.ToString();
    }
}
