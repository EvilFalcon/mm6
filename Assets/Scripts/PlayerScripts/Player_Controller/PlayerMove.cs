using UnityEngine;

namespace PlayerScripts.Player_Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.9f;
        [SerializeField] private float _speedMovet = 10f;

        private Rigidbody _ridgidbody;

        private float Epsilon;

        private void Awake()
        {
            _ridgidbody = GetComponent<Rigidbody>();
        }

        public void SetPosition(float nextPosition)
        {
            _ridgidbody.transform.Translate(new Vector3(0,0, nextPosition * _speedMovet * Time.deltaTime));
            // transform.position += nextPosition.y * transform.forward Time.deltaTime;
        }

        public void SetRotation(float yAngleDirection)
        {
            transform.Rotate(0, yAngleDirection * Time.deltaTime * _speed, 0);
        }
    }
}