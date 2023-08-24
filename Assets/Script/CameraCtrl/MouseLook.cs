using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Variable
    [SerializeField] Transform _playerBody;
    [SerializeField] float _mouseSensitivity = 100f;

    float _xRoation = 0;
    #endregion


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    void Update()
    {
        ViewCamera();
    }
    
    private void ViewCamera()
    {
        if (PopupManage.Instance.formInputPopup.gameObject.activeInHierarchy) return;
        float mouseX = Input.GetAxisRaw("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRoation -= mouseY;
        _xRoation = Mathf.Clamp(_xRoation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRoation, 0, 0);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
