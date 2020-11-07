using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private bool _jump;
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private float torquePower = 1f;
    private Rigidbody _rigidbodyComponent;
    private bool _isGrounded;
    private float _horizontalInput;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbodyComponent = GetComponent<Rigidbody>();
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

        // Debug.Log(_horizontalInput);
        // rigidbodyComponent.AddRelativeTorque(new Vector3(0, horizontalInput * torquePower, 0), ForceMode.Impulse);
        var angularVelocity = _rigidbodyComponent.angularVelocity;
        angularVelocity = new Vector3(
            angularVelocity.x,
            angularVelocity.y,
            angularVelocity.z - _horizontalInput * torquePower
        );
        _rigidbodyComponent.angularVelocity = angularVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}