using HealthPoint;
using Interface;
using PlayerScripts.PlayerComponent.Equipment;
using PlayerScripts.PlayerComponent.Resistrs;
using UnityEngine;

namespace PlayerScripts
{
    public abstract class Hero : IAttacker, IDamageable
    {
        private Health _health;
        private readonly Resists _resists;
        private readonly ParametersComponents.Parameters _parameters;

        private readonly HeroEquipment _equipment;

        protected Hero(Health health, Resists resists, ParametersComponents.Parameters parameters)
        {
            _health = health;
            _resists = resists;
            _parameters = parameters;
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }

        private void OnDied()
        {
            Debug.Log($"Герой  умер");
            OnDisable();
        }

        public void TakeDamage(int attack)
        {
            _health.TakeDamage(attack);
        }

        public void Attack(IDamageable enemy)
        {
            enemy.TakeDamage(1);
        }
    }
}