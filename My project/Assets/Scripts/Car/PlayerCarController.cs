using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Unity.Cinemachine;

public class PlayerCarController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public float speed, accelMultiplier = 3, steeringMultiplier;

    private Vector2 input = Vector2.zero;

    public Transform playerTransform;

    [SerializeField] CinemachinePanTilt cineCamera;
    [SerializeField] InputActionReference moveInputAction;

    // [SerializeField] InputAction playerAction;
    // private Vector2 playerInput;


    void Awake()
    {
        // playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Accelerate();
        Steer();
        CameraMovement();

    }

    void Update()
    {

    }

    private void Accelerate()
    {
        rb.linearDamping = 0;
        rb.AddForce(rb.transform.forward * speed * accelMultiplier);
    }

    private void Steer()
    {
        if (Mathf.Abs(input.x) > 0)
        {
            Debug.Log("Steering");
            rb.AddForce(rb.transform.right * steeringMultiplier * input.x);
        }
    }

    public void SetInput(Vector2 inputVector)
    {
        inputVector.Normalize();

        input = inputVector;
    }

    public void CameraMovement()
    {
        // Get movement input and convert it to a 3D vector
        Vector2 moveInput = moveInputAction.action.ReadValue<Vector2>();
        Vector3 moveInput3D = new Vector3(moveInput.x, 0, moveInput.y);

        // Take the pan angle from the CinemachinePanTilt component
        float panAngle = cineCamera.PanAxis.Value;
        Quaternion panRotation = Quaternion.Euler(0, panAngle, 0);

        transform.localRotation = panRotation;
    }

    // public void Move(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //     {
    //         Debug.Log("Moved");
    //         playerInput = playerAction.ReadValue<Vector2>();
    //         float horizontal = playerInput.x;

    //         rb.AddForce(rb.transform.right * steeringMultiplier * horizontal);
    //     }
    // }

    // private void OnEnable()
    // {
    //     playerAction.Enable();
    // }

    // private void OnDsable()
    // {
    //     playerAction.Disable();
    // }

}
