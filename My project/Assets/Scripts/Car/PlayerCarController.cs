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

    public float speed, accelMultiplier = 3, steeringMultiplier = 100f;

    public float accelerationTime = 2f; // Time to reach max acceleration
    private float currentAcceleration = 0f;

    private Vector2 input = Vector2.zero;

    public Transform playerTransform;

    private bool canControl = false;

    // [SerializeField] InputAction playerAction;
    // private Vector2 playerInput;


    void Awake()
    {
        // playerInput = GetComponent<PlayerInput>();
        StartCoroutine(StartDelay());
    }

    public IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3f);
        canControl = true;
    }

    private void FixedUpdate()
    {
        if (!canControl) return; // Prevents movement until the delay is over

        Accelerate();
        Steer();
    }

    void Update()
    {

    }

    private void Accelerate()
    {
        rb.linearDamping = 0;

        // Gradually increase acceleration over time
        float targetAcceleration = speed * accelMultiplier;
        currentAcceleration = Mathf.MoveTowards(currentAcceleration, targetAcceleration, (targetAcceleration / accelerationTime) * Time.fixedDeltaTime);    

        rb.AddForce(rb.transform.forward * currentAcceleration);
    }

    private void Steer()
    {
        if (Mathf.Abs(input.x) > 0 && rb.linearVelocity.magnitude > 0.1f)
        {
            float turn = input.x * steeringMultiplier * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));
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
