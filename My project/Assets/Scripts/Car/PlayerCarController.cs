using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerCarController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public float speed, accelMultiplier = 3, steeringMultiplier;

    private Vector2 input = Vector2.zero;

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
            rb.AddForce(rb.transform.right * steeringMultiplier * input.x);
        }
    }

    public void SetInput(Vector2 inputVector)
    {
        inputVector.Normalize();

        input = inputVector;
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
