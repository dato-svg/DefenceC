using System;
using UnityEngine;
using UnityEngine.UI;

public class Barricade : MonoBehaviour
{
    public Sprite[] BarriсadeSprite;

    private Animator _animator;
    private static readonly int Damage = Animator.StringToHash("Damage");


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DamageMove()
    {
        _animator.SetTrigger(Damage);
    }
}
