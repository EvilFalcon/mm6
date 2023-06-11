using UnityEngine;

namespace PlayerScripts.PlayerComponent.Player_Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.9f;
        [SerializeField] private float _speedMovet = 10f;

        private Rigidbody _rigidbody;
        private int _rotationCamera;
        private Camera _camera;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _camera = GetComponentInChildren<Camera>();
        }

        public void SetPosition(float nextPosition)
        {
            _rigidbody.transform.Translate(new Vector3(0, 0, nextPosition * _speedMovet * Time.deltaTime));
        }

        public void SetRotationCamera(float value)
        {
            int min = -20;
            int max = 20;

            if ((value < 0 && _rotationCamera <= min) || (value > 0 && _rotationCamera >= max))
                return;

            if (value < 0)
                _rotationCamera--;
            else
                _rotationCamera++;

            _camera.transform.Rotate(value, 0f, 0f);
        }

        public void SetRotationChanget(float yAngleDirection)
        {
            transform.Rotate(0, yAngleDirection * Time.deltaTime * _speed, 0);
        }
    }
}