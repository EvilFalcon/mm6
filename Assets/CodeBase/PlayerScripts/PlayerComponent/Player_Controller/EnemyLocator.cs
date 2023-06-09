﻿using Interface;
using Items.Spawners;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts.PlayerComponent.Player_Controller
{
    public class EnemyLocator : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        public bool TryGetIHurt(out IDamageable damageable) //hit.collider.TryGetComponent(out damageable)
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Mouse.current.position.value), out RaycastHit hit) && hit.collider.TryGetComponent(out ItemSpawner spawner))
            {
                spawner.Build();
                
                damageable = default;
                return true;
            }

            damageable = null;
            return false;
        }
    }
}