using System;
using HealthPoint;
using Interface;
using Items;
using PlayerScripts.Player_Controller;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerInput))]
    public class Hero : MonoBehaviour, IAttaker, IDamageable
    {
        [SerializeField] private string _name;

        [SerializeField] private int _healthPoint;
        [SerializeField] private int _damagePoint;
        private Health _health;
        private Weapon _weapon;

        public Vector3 Position { get; }
        public int WaitingTime { get; }

        //  public event Action<int> IncreasedTheLevel;
       //  public event Action<int> ChangedHealth;

        private void Awake()
        {
            _weapon = new Weapon(_damagePoint);
            _health = new Health(_healthPoint);
        }

        void Start()
        {
        }

        private void OnEnable()
        {
           // IncreasedTheLevel += _health.IncreaseHealth;
          //  ChangedHealth += _health.IncreaseHealth;
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            // IncreasedTheLevel -= _health.IncreaseHealth;
            // ChangedHealth -= _health.IncreaseHealth;
            _health.Died -= OnDied;
        }

        private void Update()
        {
        }

        private void OnDied()
        {
            Debug.Log($"Герой {_name} умер");
        }

        public void TakeDamage(int attack)
        {
            throw new NotImplementedException();
        }

        public void Attack(IDamageable enemy)
        {
            _weapon.Attack(enemy);
        }
    }
}