using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameDesign_characterController : MonoBehaviour
{
    public Camera cam;
    public float camOffset;
    public float groundDistanceTolenrance;
    public float topDistanceTolerance;
    public float rightDistanceTolenrance;
    public LayerMask groundLayerMask;
    private BoxCollider boxCollider;
    public bool isGrounded;
    public bool isBlocked;
    public bool isAtTop;
    public float? distanceToGround;
    public float? distanceToRight;
    public float? distanceToTop;

    public float speed;
    public float jumpHeight;
    public float jumpIntensity;
    public float gravity;

    private bool jumpTriggered;
    public bool hasDoubleJump;

    private bool invertedGravity;

    private float jumpStartHeight;
    private bool isJumping;

    private Rigidbody rb;

    public event Action OnJumpButtonPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        OnJumpButtonPressed += JumpButtonPressed;
        
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGrounded();
        CheckBlocked();
        CheckTop();
    }

    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(speed, 0, 0);
        if (isBlocked)
        {
            movementVector.x = 0;
        }
        movementVector.y = rb.linearVelocity.y;

        if (jumpTriggered)
        {
            isJumping = true;
            rb.useGravity = false;
            jumpStartHeight = transform.position.y;
            if (invertedGravity)
            {
                movementVector.y = -jumpIntensity;
            }
            else
            {
                movementVector.y = jumpIntensity;
            }
            jumpTriggered = false;
        }

        if (isJumping && transform.position.y >= jumpStartHeight + jumpHeight && !invertedGravity)
        {
            print("max height reached at: " + transform.position.y);
            rb.useGravity = true;
            movementVector.y = jumpIntensity + Physics.gravity.y;
            isJumping = false;
        }
        else if (isJumping && transform.position.y <= jumpStartHeight - jumpHeight && invertedGravity)
        {
            print("max height reached at: " + transform.position.y);
            rb.useGravity = true;
            movementVector.y = -jumpIntensity + Physics.gravity.y;
            isJumping = false;
        }

        rb.linearVelocity = movementVector;
        rb.AddForce(gravity * Physics.gravity);

        if (isGrounded && !isJumping &&!invertedGravity)
        {
            print("reached floor");
            hasDoubleJump = true;
        }
        else if (invertedGravity && !isJumping && isAtTop)
        {
            print("reached top");
            hasDoubleJump = true;
        }

            Vector3 camPos = cam.transform.position;
        cam.transform.position = new Vector3(transform.position.x + camOffset, camPos.y, camPos.z);
    }

    private void CheckGrounded()
    {
        float sphereCastRadius = boxCollider.size.y / 2 - 0.1f;
        Vector3 castOrigin = transform.position + new Vector3(0, boxCollider.size.y / 2, 0);
        bool isGroundBelow = Physics.SphereCast(castOrigin, sphereCastRadius, Vector3.down, out RaycastHit hitinfo, 1000, groundLayerMask, QueryTriggerInteraction.Ignore);

        if (isGroundBelow)
        {
            distanceToGround = transform.position.y - hitinfo.point.y;
        }
        else
        {
            distanceToGround = null;
        }

        isGrounded = isGroundBelow && distanceToGround <= groundDistanceTolenrance;
    }

    private void CheckBlocked()
    {
        Vector3 boxHalf = boxCollider.size / 2;
        Vector3 castOrigin = transform.position + new Vector3(-0.1f, boxCollider.size.y / 2, 0);
        bool isBlockedRight = Physics.BoxCast(castOrigin, boxHalf, Vector3.right, out RaycastHit hitinfo, transform.rotation, 1000, groundLayerMask, QueryTriggerInteraction.Ignore);

        if (isBlockedRight)
        {
            distanceToRight = hitinfo.point.x - transform.position.x;
        }
        else
        {
            distanceToRight = null;
        }

        isBlocked = isBlockedRight && distanceToRight <= rightDistanceTolenrance;
    }

    private void CheckTop()
    {
        float sphereCastRadius = boxCollider.size.y / 2 - 0.1f;
        Vector3 castOrigin = transform.position - new Vector3(0, boxCollider.size.y / 2, 0);
        bool hasCeiling = Physics.SphereCast(castOrigin, sphereCastRadius, Vector3.up, out RaycastHit hitinfo, 1000, groundLayerMask, QueryTriggerInteraction.Ignore);

        if (hasCeiling)
        {
            distanceToTop = hitinfo.point.y - transform.position.y;
        }
        else
        {
            distanceToTop = null;
        }

        isAtTop = hasCeiling && distanceToTop <= topDistanceTolerance;
    }

    public void invertGravity()
    {
        if (!invertedGravity)
        {
            invertedGravity = true;
        }
        else
        {
            invertedGravity = false;
        }
        Physics.gravity *= -1;
    }

    private void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed && isGrounded && !invertedGravity)
        {
            OnJumpButtonPressed?.Invoke();
        }
        else if(inputValue.isPressed && isAtTop && invertedGravity)
        {
            OnJumpButtonPressed?.Invoke();
        }
        else if (inputValue.isPressed && hasDoubleJump)
        {
            hasDoubleJump = false;
            OnJumpButtonPressed?.Invoke();
        }
    }


    private void JumpButtonPressed()
    {
        jumpTriggered = true;
    }
}
