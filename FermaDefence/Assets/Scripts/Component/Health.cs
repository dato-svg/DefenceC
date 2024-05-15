using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Component
{
    public class Health : MonoBehaviour
    { 
        public int maxHealth;
        [SerializeField] private UnityEvent onDamage;
        [SerializeField] private UnityEvent onDie;

        [HideInInspector] public int _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        [ContextMenu("Damage")]
        public void Damage(int damage)
        {
            _currentHealth -= damage;
            onDamage?.Invoke();
            if (_currentHealth <= 0)
            {
                onDie?.Invoke();
            }
        }
    }
}
