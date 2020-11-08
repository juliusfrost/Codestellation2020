﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private bool _jump;
    [SerializeField] private float jumpPower = 5;
    [SerializeField] private float torquePower = 1f;
    private Rigidbody _rigidbodyComponent;
    private bool _isGrounded;
    private int _numCollisions;
    private float _horizontalInput;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbodyComponent = GetComponent<Rigidbody>();
        _numCollisions = 0;
        _isGrounded = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
        }

        _horizontalInput = Input.GetAxis("Horizontal");
    }

    // called every physics update
    private void FixedUpdate()
    {
        if (_jump)
        {
            if (_isGrounded)
                _rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            _jump = false;
        }

        _isGrounded = false;

        // Debug.Log(_horizontalInput);
        // rigidbodyComponent.AddRelativeTorque(new Vector3(0, horizontalInput * torquePower, 0), ForceMode.Impulse);
        _rigidbodyComponent.AddTorque(0, 0, -_horizontalInput * torquePower, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision other)
    {
        _isGrounded = other.contacts.Any(contactPoint => contactPoint.point.y < _rigidbodyComponent.position.y);
    }
}