﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPointer;

    [SerializeField]
    private CameraPointerScript cameraPointerScript;

    void Update()
    {
        transform.LookAt(cameraPointer.position, Vector3.up);

        transform.position = Vector3.up*cameraPointerScript.GetDistance();
    }
}
