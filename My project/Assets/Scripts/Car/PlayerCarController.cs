using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;

public class PlayerCarController : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public float speed, accelMultiplier = 3;

    //Inputs
    public InputAction playerInput;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        Accelerate();

        Steering();
    }

    void Update()
    {

    }

    private void Accelerate()
    {
        rb.linearDamping = 0;
        rb.AddForce(rb.transform.forward * speed * accelMultiplier);
    }

    private void Steering()
    {
      
    }

}
