using System;
using HealthPoint;
using Interface;
using Items;
using UnityEngine;

namespace EnamyScripts
{
    [RequireComponent(
        typeof(Health),
        typeof(Weapon))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _healthPoint;
        [SerializeField] private int _damagePoint;
        private Health _health;
        private Weapon _weapon;

        public Vector3 Position { get; private set; }

        private void Awake()
        {
            _health = new Health(_healthPoint);
            _weapon = new Weapon(_damagePoint);
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
            Debug.Log($"hels Spider {_health.Value}");
        }
    }
}