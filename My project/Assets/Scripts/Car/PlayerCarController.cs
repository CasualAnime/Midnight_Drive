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

    private PlayerInput playerInput;


    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        //playerInputActions.Player.Move.performed += Move_performed;
    }

    private void FixedUpdate()
    {
        Accelerate();

    }

    void Update()
    {

    }

    private void Accelerate()
    {
        rb.linearDamping = 0;
        rb.AddForce(rb.transform.forward * speed * accelMultiplier);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Moved");
            rb.AddForce(rb.transform.right * steeringMultiplier);
        }
    }

}
