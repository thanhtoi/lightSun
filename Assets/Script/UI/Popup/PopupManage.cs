using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManage : MonoBehaviour
{
    #region VARIABLE
    public static PopupManage Instance { get; private set; }

    //popup manager

    public FormInputPopup formInputPopup;
    public MessPopup mesPopup;

    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #region ONCLICK EVENT

    public void OnClickEditSun()
    {
        formInputPopup.gameObject.SetActive(true);
    }

    #endregion
}
