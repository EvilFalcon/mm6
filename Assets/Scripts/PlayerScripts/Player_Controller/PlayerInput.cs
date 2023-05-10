using System;
using Interface;
using UnityEngine;

namespace PlayerScripts.Player_Controller
{
    [RequireComponent(typeof(PlayerMove))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private PlayerMove _playerMove;
        private Player _player;
        private EnemyLocator _locator;

        public event Action<float> PositionChanget;
        public event Action<float> PositionRotation;

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _playerMove = GetComponent<PlayerMove>();
            _player = GetComponent<Player>();
            _locator = GetComponent<EnemyLocator>();
        }

        public void Update()
        {
            Move();
            Rotation();
        }

        private void OnEnable()
        {
            _playerControls.ControlPlayer.AttackTheTarget.performed += ctx => Attack();
            _playerControls.ControlPlayer.LookUpandDown.performed += ctx => LookUp();
            _playerControls.ControlPlayer.Move.performed += ctx => Move();
            _playerControls.ControlPlayer.ChangetRotation.performed += ctx => Rotation();
            PositionChanget += _playerMove.SetPosition;
            PositionRotation += _playerMove.SetRotation;
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();

            _playerControls.ControlPlayer.AttackTheTarget.performed -= ctx => Attack();
            _playerControls.ControlPlayer.LookUpandDown.performed -= ctx => LookUp();
            _playerControls.ControlPlayer.Move.performed -= ctx => Move();
            _playerControls.ControlPlayer.ChangetRotation.performed -= ctx => Rotation();
            PositionChanget -= _playerMove.SetPosition;
            PositionRotation -= _playerMove.SetRotation;
        }

        private void Attack()
        {
            if (_playerControls.ControlPlayer.AttackTheTarget.IsPressed() == false)
                return;
            
            if (_locator.TryGetIHurt(out IDamageable enemy) == false)
                return;

            _player.Attack(enemy);
        }

        private void LookUp()
        {
        }

        private void Move()
        {
            PositionChanget?.Invoke(_playerControls.ControlPlayer.Move.ReadValue<float>());
        }

        private void Rotation()
        {
            PositionRotation?.Invoke(_playerControls.ControlPlayer.ChangetRotation.ReadValue<float>());
        }
    }
}