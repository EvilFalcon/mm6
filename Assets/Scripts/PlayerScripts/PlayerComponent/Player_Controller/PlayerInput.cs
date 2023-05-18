using System;
using Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts.PlayerComponent.Player_Controller
{
    [RequireComponent(typeof(PlayerMove))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private PlayerMove _playerMove;
        private Player _player;
        private EnemyLocator _locator;

        public event Action<float> PositionChanget;
        public event Action<float> RotationChanget;
        public event Action<float> RotationXCameraChanget;

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
            _playerControls.ControlPlayer.AttackTheTarget.performed += Attack;
            _playerControls.ControlPlayer.LookUpandDown.performed += LookUpAndDown;
            PositionChanget += _playerMove.SetPosition;
            RotationChanget += _playerMove.SetRotationChanget;
            RotationXCameraChanget += _playerMove.SetRotationCamera;
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();

            _playerControls.ControlPlayer.AttackTheTarget.performed -= Attack;
            _playerControls.ControlPlayer.LookUpandDown.performed -= LookUpAndDown;
            PositionChanget -= _playerMove.SetPosition;
            RotationChanget -= _playerMove.SetRotationCamera;
            RotationXCameraChanget -= _playerMove.SetRotationChanget;
        }

        private void Attack(InputAction.CallbackContext _)
        {
            if (_locator.TryGetIHurt(out IDamageable enemy) == false)
                return;

            _player.Attack(enemy);
        }

        private void LookUpAndDown(InputAction.CallbackContext _)
        {
            RotationXCameraChanget?.Invoke(_playerControls.ControlPlayer.LookUpandDown.ReadValue<float>());
        }

        private void Move()
        {
            PositionChanget?.Invoke(_playerControls.ControlPlayer.Move.ReadValue<float>());
        }

        private void Rotation()
        {
            RotationChanget?.Invoke(_playerControls.ControlPlayer.ChangetRotation.ReadValue<float>());
        }
    }
}