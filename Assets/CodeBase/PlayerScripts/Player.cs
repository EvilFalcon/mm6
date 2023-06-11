using System;
using Interface;
using PlayerScripts.PlayerComponent.Player_Controller;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour, IAttacker, IDamageable
    {
        [SerializeField] private Hero _hero1;
        [SerializeField] private Hero _hero2;
        [SerializeField] private Hero _hero3;
        [SerializeField] private Hero _hero4;

        private Hero[] _detachment;

        private void Awake()
        {
            _detachment = new Hero[] { _hero1, _hero2, _hero3, _hero4 };
        }

        public void Attack(IDamageable enemy)
        {
            if (enemy == null)
                return;

            _hero1.Attack(enemy);
        }

        public Vector3 Position { get; }

        public void TakeDamage(int attack)
        {
            throw new NotImplementedException();
        }
    }
}