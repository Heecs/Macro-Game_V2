using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameDesign_characterController : MonoBehaviour
{
    public Camera cam;
    public float camOffset;

    public float speed;
    public float jumpSpeed;
    public float gravity;

    private bool jumpTriggered;

    private Rigidbody rb;

    public event Action OnJumpButtonPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OnJumpButtonPressed += JumpButtonPressed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(speed, 0, 0);
        movementVector.y = rb.linearVelocity.y;

        if (jumpTriggered)
        {
            print("jumping");
            movementVector.y = jumpSpeed;
            jumpTriggered = false;
        }

        rb.linearVelocity = movementVector;
        rb.AddForce(gravity * Physics.gravity);

        Vector3 camPos = cam.transform.position;
        cam.transform.position = new Vector3(transform.position.x + camOffset, camPos.y, camPos.z);
    }

    private void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            OnJumpButtonPressed?.Invoke();
        }
    }

    private void JumpButtonPressed()
    {
        jumpTriggered = true;
    }
}
