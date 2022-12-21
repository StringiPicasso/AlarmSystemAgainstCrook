using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    private const string Xposition = "Xposition";
    private const string IsWalking = "isWalking";

    [SerializeField] private float _moveSpeed = 2f;

    private Vector2 _moveInput;
    private Rigidbody2D _playerRigidbody;
    private Animator _animator;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _playerRigidbody.MovePosition(_playerRigidbody.position + _moveInput * _moveSpeed * Time.fixedDeltaTime);
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();

        if (_moveInput.x != 0)
        {
            _animator.SetFloat(Xposition, _moveInput.x);
            _animator.SetBool(IsWalking, true);
        }
        else
        {
            _animator.SetBool(IsWalking, false); 
        }
    }
}
