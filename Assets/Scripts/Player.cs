using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    Rigidbody rb;
    Rigidbody rb2;
    private CharacterController _controller;
    //[SerializeField] private float _speed = 10;
    [SerializeField] private float _gravity = 10;
    [SerializeField] private float _jumpHeight = 10f;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float pushForce = 6f;
    [SerializeField] float forceMagnitude = 6f;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;

    private float _yVelocity;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _yVelocity = _jumpHeight;
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb2 = hit.collider.attachedRigidbody;
        if (rb2 != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rb2.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .2f, ground);

    }
}
