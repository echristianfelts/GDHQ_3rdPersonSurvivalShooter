﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Speed
    [SerializeField]
    private float _speed = 5.0f;
    //Jumpheight
    [SerializeField]
    private float _jumpForce = 15.0f;
    //Gravity
    [SerializeField]
    private float _gravity = 20.0f;
    //Direction
    private Vector3 _direction;

    [Header("Input Feedback.  Output only.")]
    [SerializeField]
    private float _xInput;
    [SerializeField]
    private float _zInput;

    [SerializeField]
    private float mouseX, mouseY;

    //  Get handle to character controller
    private CharacterController _controller;



    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.LogError("No Character Controller Found...");
        }

        //  Lock cursor & hide it.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        TurnPlayer();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        //  if escape key
        //  bring the cursor back...


    }

    private void UpdateMovement()
    {
        if (_controller.isGrounded == true)
        {
            _xInput = Input.GetAxis("Horizontal");
            _zInput = Input.GetAxis("Vertical");

            ////////// Movement Player.
            _direction = new Vector3(_xInput, 0, _zInput) * _speed;

            ////////// Player Jump.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _direction.y += _jumpForce;
            }


            _direction = transform.TransformDirection(_direction);  //Makes character face direction it is moving in.  Not sure I completly understand it though...


        }

        _direction.y -= _gravity * Time.deltaTime;

        _controller.Move(_direction * Time.deltaTime);

    }

    private void TurnPlayer()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        Vector3 _facing = transform.localEulerAngles;
        _facing.y += mouseX;
        this.transform.localRotation = Quaternion.AngleAxis(_facing.y, Vector3.up);
    }

    void OnMouseDown()
    {
        // Lock the cursor
        Cursor.visible = false;
    }
}
