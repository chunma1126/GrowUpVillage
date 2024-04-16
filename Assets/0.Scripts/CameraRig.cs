using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    private float mouseWheel;
    private void Start()
    {
        mouseWheel = 15;
    }

    void Update()
    {
        RigMovement();
        
        ZoomCamera();
    }

    void ZoomCamera()
    {
        mouseWheel = Input.GetAxisRaw("Mouse ScrollWheel") * -1;
    
        float zoomAmount = mouseWheel * zoomSpeed;

        float currentDistance = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance;

        float newDistance = currentDistance + zoomAmount;

        newDistance = Mathf.Clamp(newDistance, 5f, 30f);

        _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = newDistance;
    }



    private void RigMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, 0, y).normalized * speed * Time.deltaTime;
    }
}
