using UnityEngine;

/// <summary>
/// CharacterController-based locomotion using the old Input System for quick iteration.
/// For production, input should be event-driven and movement should be part of a 
/// state-driven character architecture. Includes acceleration, gravity, and jumping.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float acceleration = 12f;
    [SerializeField] float deceleration = 12f;
    [SerializeField] float jumpHeight = 1.2f;
    [SerializeField] float gravity = -20f;

    CharacterController _controller;

    Vector3 _movementVelocity;
    Vector3 _verticalVelocity;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ProcessHorizontalMovement();
        ProcessVerticalMovement();

        ApplyMovement();
    }

    void ProcessHorizontalMovement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = (transform.right * inputX + transform.forward * inputZ).normalized;
        Vector3 desiredVelocity = inputDirection * moveSpeed;

        bool accelerating = desiredVelocity.magnitude > _movementVelocity.magnitude;
        float rate = accelerating ? acceleration : deceleration;

        _movementVelocity = Vector3.MoveTowards(
            _movementVelocity,
            desiredVelocity,
            rate * Time.deltaTime
        );
    }

    void ProcessVerticalMovement()
    {
        if (_controller.isGrounded)
        {
            _verticalVelocity.y = -2f;

            if (Input.GetButtonDown("Jump"))
                _verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else
        {
            _verticalVelocity.y += gravity * Time.deltaTime;
        }
    }

    void ApplyMovement()
    {
        Vector3 totalVelocity = _movementVelocity + _verticalVelocity;
        _controller.Move(totalVelocity * Time.deltaTime);
    }
}
