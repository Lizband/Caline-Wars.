using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float jumpForce = 3f;

    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerMovement();
        Jumping();
        
    }

    void PlayerMovement()
    {
        // Player movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moverDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moverDir.normalized * speed * Time.deltaTime);
        }
    }

    void Jumping()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.V) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Gravity 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
