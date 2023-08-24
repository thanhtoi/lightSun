using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _playercrtl;
    [SerializeField] float speed = 16f;
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (PopupManage.Instance.formInputPopup.gameObject.activeInHierarchy) return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _playercrtl.Move(move * speed * Time.deltaTime);
    }
}

