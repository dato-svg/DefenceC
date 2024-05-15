using System.Collections;
using Component;
using UnityEngine;

namespace Controller
{
    public class MoveEnemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Move1 = Animator.StringToHash("Move");

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
            _animator.SetBool(Move1 , true);
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(speed,_rigidbody2D.velocity.y);
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Barricade>() != null)
            {
                _animator.SetBool(Move1 , false);
                StartCoroutine(AttackActivator(other));

            }
        }

        private IEnumerator AttackActivator(Collision2D other)
        {
            while (true)
            {
                _animator.SetTrigger(Attack);
                other.gameObject.GetComponent<Health>().Damage(1);
                yield return new WaitForSeconds(1f);
            }
           
        }
    }
}
