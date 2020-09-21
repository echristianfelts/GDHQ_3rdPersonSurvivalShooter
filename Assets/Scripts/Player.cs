using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Speed
    [SerializeField]
    private float _speed = 5.0f;
    //Jumpheight
    [SerializeField]
    private float _jumpForce = 5.0f;
    private float _jumpForceMod;
    //Gravity
    [SerializeField]
    private float _gravity = 1.0f;
    //Direction
    private Vector3 _direction;

    [SerializeField]
    private float _xInput;
    [SerializeField]
    private float _zInput;

    //  Get handle to character controller
    private CharacterController _controller;



    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller.isGrounded == true)
        {
            //  wsad keys for movement
            //  input system(horizontal, vertical)
            _xInput = Input.GetAxis("Horizontal");
            _zInput = Input.GetAxis("Vertical");

            //  direction = vector to move
            _direction = new Vector3(_xInput, 0, _zInput) * _speed;

            //  velocity = direction * speed
            //
            //  if jump
            //  velocity = new velocity with added y
            if (Input.GetKeyDown(KeyCode.Space))
            {

                _direction.y += _jumpForce;
                //_anim.SetTrigger("Jump");

                //_jumping = true;
                //_anim.SetBool("Jumping", _jumping);
            }
        }
        _direction.y -= _gravity * Time.deltaTime;
        

        //
        //  controler.move(wsad*time.delta)
        _controller.Move(_direction * Time.deltaTime);
    }
}
