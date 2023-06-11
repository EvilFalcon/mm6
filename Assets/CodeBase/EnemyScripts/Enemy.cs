using HealthPoint;
using Interface;
using Items.ItemComponent.WeaponComponent.DamageType;
using UnityEngine;

namespace EnemyScripts
{
    [RequireComponent(
        typeof(Health),
        typeof(Magic))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _healthPoint;

        private Health _health;

        public Vector3 Position { get; private set; }

        private void Awake()
        {
            _health = new Health(_healthPoint);
        }

        private void OnEnable()
        {
            _health.Died += OnDisable;
            gameObject.SetActive(true);
            Position = transform.position;
        }

        private void OnDisable()
        {
            _health.Died -= OnDisable;
            gameObject.SetActive(false);
            _health = new Health(_health.Max);
        }

        private void OnDestroy()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(int attack)
        {
            _health.TakeDamage(attack);
        }
    }
}