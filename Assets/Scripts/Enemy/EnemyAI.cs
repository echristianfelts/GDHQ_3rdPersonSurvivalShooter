using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    // Referece Character Controller
    private CharacterController _controller;
    
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _gravity = 20.0f;

    private GameObject _target;

    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        //  Check if grounded
        //  calculate direction = destination(player or target) - source (self (transform))
        //  Calculate velocity = direction * Speed

        //  Might need to Transform to world space (or local space...) 

        //  Subtract gravity
        //  move to velocity




    }

    private void UpdateMovement()
    {

        if (_controller.isGrounded == true)
        {
            _direction = _target.transform.position - this.transform.position;
            _direction.Normalize();
            _direction.y = 0;
            this.transform.localRotation = Quaternion.LookRotation(_direction);
            _direction *= _speed;
            Debug.Log("Self Pos :" + this.transform.position + "  Target Pos :" + _target.transform.position);

        }



        _direction.y -= _gravity;
        _controller.Move(_direction * Time.deltaTime);


    }
}
