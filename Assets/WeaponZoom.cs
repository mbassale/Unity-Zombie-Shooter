using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private float zoomedOutFOV = 60f;
    [SerializeField] private float zoomedInFOV = 20f;
    [SerializeField] private float zoomOutSensitivity = 2f;
    [SerializeField] private float zoomInSensitivity = 0.5f;
    private Camera fpsCamera;
    private bool zoomedIn = false;
    private float zoomValue;
    private RigidbodyFirstPersonController fpsController;

    private void Start()
    {
        fpsCamera = Camera.main;
        zoomValue = zoomedOutFOV;
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            zoomedIn = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            zoomedIn = false;
        }

        if (zoomedIn)
        {
            if (zoomValue > zoomedInFOV)
            {
                zoomValue = Mathf.LerpUnclamped(zoomValue, zoomedInFOV, Time.deltaTime * 10f);
            }
            fpsCamera.fieldOfView = zoomValue;
            fpsController.mouseLook.XSensitivity = zoomInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomInSensitivity;
        }
        else
        {
            if (zoomValue < zoomedOutFOV)
            {
                zoomValue = Mathf.LerpUnclamped(zoomValue, zoomedOutFOV, Time.deltaTime * 10f);
            }
            fpsCamera.fieldOfView = zoomValue;
            fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
        }
    }
}