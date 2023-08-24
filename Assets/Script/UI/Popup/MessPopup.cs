using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessPopup : MonoBehaviour
{
    #region VARIABLE

    [SerializeField] TextMeshProUGUI _txtMessError;

    #endregion


    #region ONCLICK EVENT
    public void OnClickOverLay()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClickOke()
    {
        this.gameObject.SetActive(false);
    }

    public void OnshowMes(string mesError)
    {
        _txtMessError.text = mesError;
        this.gameObject.SetActive(true);
    }
    #endregion
}
