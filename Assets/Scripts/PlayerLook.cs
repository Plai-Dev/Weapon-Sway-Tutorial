using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    [Header("References")] 
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform orientation;

    [Header("Look Settings")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    private float yRotation;
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * Time.deltaTime * 100f;
        xRotation -= mouseY * sensY * Time.deltaTime * 100f;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
        cameraHolder.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }

}
