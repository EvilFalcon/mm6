using System;
using UnityEngine;

namespace WorldTime
{
    public class WorldTime : MonoBehaviour
    {
        private DateTime _dateTime;
        private bool _isWork;

        public int Minute => _dateTime.Minute;
        public int Hour => _dateTime.Hour;
        public int Day => _dateTime.Day;
        public int Month => _dateTime.Month;
        public int Year => _dateTime.Year;

        private void Awake()
        {
            _dateTime = new DateTime(1165, 1, 1, 9, 0, 0);
        }

        private void Update()
        {
            if (_isWork)
            {
                _dateTime = _dateTime.AddMinutes(Time.deltaTime);
            }
        }

        public void StartTik()
        {
            _isWork = true;
        }

        public void StopTik()
        {
            _isWork = false;
        }
    }
}