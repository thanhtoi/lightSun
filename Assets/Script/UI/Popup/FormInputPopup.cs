using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SunRealTime;
using System;

public class FormInputPopup : MonoBehaviour
{
    #region VARIALBE
    [Header("Input Data")]
    [SerializeField] TMP_InputField _txtLatitude;
    [SerializeField] TMP_InputField _txtLongitude;
    [SerializeField] TMP_InputField _txtMonth;
    [SerializeField] TMP_InputField _txtDay;
    [SerializeField] TMP_InputField _txtHour;
    [SerializeField] TMP_InputField _txtMinutes;
    [SerializeField] TMP_InputField _txtTimeSpeed;

    [SerializeField] Sun _sun;
    #endregion


    #region ONCLICK EVEN
    public void OnClickSutmit()
    {
        string tempMes = CheckInputValid();
        if (tempMes != "")
        {
            PopupManage.Instance.mesPopup.OnshowMes(tempMes);
        }
        else
        {
            this.gameObject.SetActive(false);
            SetValueToSun();
        }

    }

    public void OnClickClosePopup(GameObject popup)
    {
        popup.SetActive(false);
    }

    #endregion


    #region Process formPopup
    private string CheckInputValid()
    {
        string mesError = "";
        if (_txtLatitude.text != "")
        {

            if (int.Parse(_txtLatitude.text) > 90 || int.Parse(_txtLatitude.text) < -90)
            {
                mesError = "Latitude must be in the range -90 -> 90";
                return mesError;
            }
        }
        if (_txtLongitude.text != "")
        {

            if (int.Parse(_txtLongitude.text) > 360 || int.Parse(_txtLongitude.text) < 0)
            {
                mesError = "Longitude must be in the range 0 -> 360";
                return mesError;
            }
        }
        if (_txtMonth.text != "")
        {

            if (int.Parse(_txtMonth.text) > 12 || int.Parse(_txtMonth.text) < 1)
            {
                mesError = "Valid month from 1 -> 12";
                return mesError;
            }
        }
        if (_txtDay.text != "")
        {

            if (int.Parse(_txtDay.text) > 31 || int.Parse(_txtDay.text) < 1)
            {
                mesError = "Valid month from 1 -> 31";
                return mesError;
            }
        }
        if (_txtHour.text != "")
        {

            if (int.Parse(_txtHour.text) > 24 || int.Parse(_txtHour.text) < 0)
            {
                mesError = "Valid Hour from 0 -> 24";
                return mesError;
            }
        }
        if (_txtMinutes.text != "")
        {

            if (int.Parse(_txtMinutes.text) > 60 || int.Parse(_txtMinutes.text) < 0)
            {
                mesError = "Valid Hour from 0 -> 60";
                return mesError;
            }
        }
        return mesError;
    }

    private void SetValueToSun()
    {
        if (_txtLatitude.text != "")
        {
            _sun.SetLatitude(float.Parse(_txtLatitude.text));
        }
        if (_txtLongitude.text != "")
        {
            _sun.SetLongitude(float.Parse(_txtLongitude.text));
        }

        if (_txtTimeSpeed.text != "")
        {
            _sun.SetTimeSpeed(float.Parse(_txtTimeSpeed.text));
        }
        if (_txtMonth.text != "" || _txtDay.text != "")
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            if (_txtDay.text != "")
            {
                day = int.Parse(_txtDay.text);
            }
            if (_txtMonth.text != "")
            {
                month = int.Parse(_txtMonth.text);
            }
            DateTime date = new DateTime(year, month, day);
            _sun.SetDate(date);

            //Debug.Log(date.ToString("yyyy-MM-dd h:mm:ss"));
        }
        if (_txtHour.text != "" || _txtMinutes.text != "")
        {
            int minutes = 0;
            int hour = 0;
            if (_txtHour.text != "")
            {
                hour = int.Parse(_txtHour.text);
            }
            if (_txtMinutes.text != "")
            {
                minutes = int.Parse(_txtMinutes.text);
            }
            _sun.SetTime(hour, minutes);
        }
    }
    
    private void ResetInputfield()
    {
        _txtLatitude.text = "";
        _txtLongitude.text = "";
        _txtMonth.text = "";
        _txtDay.text = "";
        _txtHour.text = "";
        _txtMinutes.text = "";
        _txtTimeSpeed.text = "";
    }
    
    #endregion
}
