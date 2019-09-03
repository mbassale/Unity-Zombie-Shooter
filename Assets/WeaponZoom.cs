using System;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private float zoomedOutFOV = 60f;
    [SerializeField] private float zoomedInFOV = 20f;
    private Camera fpsCamera;
    private bool zoomedIn = false;
    private float zoomValue;

    private void Start()
    {
        fpsCamera = Camera.main;
        zoomValue = zoomedOutFOV;
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
        }
        else
        {
            if (zoomValue < zoomedOutFOV)
            {
                zoomValue = Mathf.LerpUnclamped(zoomValue, zoomedOutFOV, Time.deltaTime * 10f);
            }
            fpsCamera.fieldOfView = zoomValue;
        }
    }
}