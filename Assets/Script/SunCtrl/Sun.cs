using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunRealTime
{

    [RequireComponent(typeof(Light))]
    public class Sun : MonoBehaviour
    {

        #region VARIABLE
        [SerializeField] float _longitude;
        [SerializeField] float _latitude;
        [SerializeField] [Range(0, 24)] int _hour;
        [SerializeField] [Range(0, 60)] int _minutes;


        DateTime _time;
        Light _light;

        [SerializeField] float _timeSpeed = 1;
        [SerializeField] int _frameSteps = 1;
        int _frameStep;

        [SerializeField] DateTime _date;
        #endregion


        #region SET VALUE SUN
        public void SetTime(int hour, int minutes)
        {
            this._hour = hour;
            this._minutes = minutes;
            OnValidate();
        }

        public void SetLocation(float longitude, float latitude)
        {
            this._longitude = longitude;
            this._latitude = latitude;
        }

        public void SetLongitude(float longitude)
        {
            this._longitude = longitude;
        }

        public void SetLatitude(float latitude)
        {
            this._latitude = latitude;
        }

        public void SetDate(DateTime dateTime)
        {
            this._hour = dateTime.Hour;
            this._minutes = dateTime.Minute;
            this._date = dateTime.Date;
            OnValidate();
        }

        public void SetUpdateSteps(int i)
        {
            _frameSteps = i;
        }

        public void SetTimeSpeed(float speed)
        {
            _timeSpeed = speed;
        }

        #endregion

        private void Awake()
        {

            _light = GetComponent<Light>();
            _time = DateTime.Now;
            _hour = _time.Hour;
            _minutes = _time.Minute;
            _date = _time.Date;
        }

        private void OnValidate()
        {
            _time = _date + new TimeSpan(_hour, _minutes, 0);

            //   Debug.Log(time);
        }

        private void Update()
        {
            _time = _time.AddSeconds(_timeSpeed * Time.deltaTime);
            if (_frameStep == 0)
            {
                SetPosition();
            }
            _frameStep = (_frameStep + 1) % _frameSteps;


        }

        void SetPosition()
        {

            Vector3 angles = new Vector3();
            double alt;
            double azi;
            SunPosition.CalculateSunPosition(_time, (double)_latitude, (double)_longitude, out azi, out alt);
            angles.x = (float)alt * Mathf.Rad2Deg;
            angles.y = (float)azi * Mathf.Rad2Deg;
            //  Debug.Log(angles);
            transform.localRotation = Quaternion.Euler(angles);
            _light.intensity = Mathf.InverseLerp(-12, 0, angles.x);
        }

    }
}