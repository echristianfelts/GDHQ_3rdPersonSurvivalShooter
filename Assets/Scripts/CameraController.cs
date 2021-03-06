﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _cameraResponsiveness = 1.0f;

    [SerializeField]
    private float _cameraCenterResponsiveness = 1.0f;

    [SerializeField]
    private float _cameraClampHigh = 3.0f;

    [SerializeField]
    private float _cameraClampLow = 30.0f;


    [Header("Input Display.  Output Only.")]
    [SerializeField]
    private float mouseX;
    [SerializeField]
    private float mouseY;
    [SerializeField]
    public float _cameraClampDisplay;

    private Vector3 _camStartAngle;

    // Start is called before the first frame update
    void Start()
    {
        _camStartAngle = this.transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {   
        //  Get Inputs.
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //  Calculate.
        Vector3 _facing = transform.localEulerAngles;
        _facing.x -= mouseY* _cameraResponsiveness;
        _facing.x = Mathf.Clamp(_facing.x, _cameraClampHigh, _cameraClampLow);

        //if (_facing.x <= _cameraClampHigh)
        //{
        //    _facing.x = _cameraClampHigh;
        //} else 
        //if (_facing.x >= _cameraClampLow)
        //{
        //    _facing.x = _cameraClampLow;
        //}

        _cameraClampDisplay = _facing.x;
        // Set Rotation.
        this.transform.localRotation = Quaternion.AngleAxis(_facing.x, Vector3.right); 

        // Reset Camera Rotation.
        this.transform.localEulerAngles = Vector3.MoveTowards(this.transform.localEulerAngles, _camStartAngle, Time.deltaTime * _cameraCenterResponsiveness);

    }
}
