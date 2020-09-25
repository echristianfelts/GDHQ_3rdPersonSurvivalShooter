using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    // Referece Character Controller
    private CharacterController _controller;
    
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _gravity = 20.0f;
    private GameObject _target;
    private Vector3 _direction;

    private Health _targetHealth;

    [SerializeField]
    private float _weaponReloadTime = 1.5f;
    private float _nextAttack = -1f;

    [SerializeField]
    private EnemyState _currentState = EnemyState.Chase;




    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _target = GameObject.FindGameObjectWithTag("Player");
        _targetHealth = _target.GetComponent<Health>();

        if (_target == null || _targetHealth == null)
        {
            Debug.Log("Targeted Components are null...");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (_currentState == EnemyState.Chase)
        {
            UpdateMovement();
        }

        if (_currentState == EnemyState.Attack)
        {
            if (Time.time > _nextAttack)
            {
                if (_targetHealth != null)
                {
                    _targetHealth.currentHealth -= _targetHealth.damageAmount;
                }
                _nextAttack = Time.time + _weaponReloadTime;
            }


        }
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
        }
        _direction.y -= _gravity;
        _controller.Move(_direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //  begin attacking
        if(other.tag == "Player")
        {
            _currentState = EnemyState.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _currentState = EnemyState.Chase;
        }
    }
}
