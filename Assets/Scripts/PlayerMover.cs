using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    private Camera mainCamera;
    private Rigidbody rb;
    private Vector3 movementDirection;

    private void Start() 
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        MovePlayer();
    }

    private void FixedUpdate() 
    {
        if (movementDirection == Vector3.zero) { return; }
        
        rb.AddForce(movementDirection * forceMagnitude, ForceMode.Force);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);

    }

    private void MovePlayer()
    {
        if ((Touchscreen.current.primaryTouch.press.isPressed))
        {
           Vector2 touchPosition =  Touchscreen.current.primaryTouch.position.ReadValue(); //returns screen position of touch
           Vector3 worldPOsition = mainCamera.ScreenToWorldPoint(touchPosition); //converts touch position to world position

           movementDirection = transform.position - worldPOsition; //move away from touch position
           movementDirection.z = 0;
           movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }
}
