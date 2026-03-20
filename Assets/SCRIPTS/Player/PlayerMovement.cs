using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Camera Rotation
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;

    // Ground Movement
    private Rigidbody rb;
    public float MoveSpeed = 5f;
    private float moveHorizontal;
    private float moveForward;

    // Jumping
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f; // Multiplies gravity when falling down
    public float ascendMultiplier = 2f; // Multiplies gravity for ascending to peak of jump
    private bool isGrounded = false;
    public LayerMask groundLayer;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerHeight;
    private float raycastDistance;

    //Animations
    private AnimationSwitcher animationSwitcher;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = Camera.main.transform;

        // Set the raycast to be slightly beneath the player's feet
        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;

        // Hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animationSwitcher = GetComponent<AnimationSwitcher>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        RotateCamera();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Checking when we're on the ground and keeping track of our ground check delay
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        MovePlayer();
        ApplyJumpPhysics();
    }

    void MovePlayer()
    {
        animationSwitcher.ChangeAnimation();
        Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
        Vector3 targetVelocity = movement * MoveSpeed;

        // Cast a ray to check the ground in front of the player.
        // We use this to figure out whether the player is on a slope.
        RaycastHit hit;
        // Start the ray near the player's feet.
        Vector3 rayOrigin = transform.position - (Vector3.up * (playerHeight / 2 - 0.5f));
        // Point mostly downward, but slightly forward so we can detect the slope ahead.
        Vector3 rayDirection = (Vector3.down + transform.forward * 0.5f).normalized;
        // Draw the ray in Scene view to help with debugging.
        Debug.DrawRay(rayOrigin, rayDirection * 2f, Color.cyan);


        
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 2f, groundLayer))
        {
            // Compare the ground's normal against world up to get the slope angle.
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            
            // Only apply climb assist on valid slopes (not flat and not near-vertical walls).
            if (slopeAngle > 0 && slopeAngle < 80f)
            {
                // Find downhill direction along the slope surface.
                Vector3 downhillDirection = Vector3.ProjectOnPlane(Vector3.down, hit.normal).normalized;
                // Uphill is the opposite of downhill.
                Vector3 uphillDirection = -downhillDirection;
                // True only when player input is mostly pointing uphill.
                bool movingUphill = movement.sqrMagnitude > 0.001f && Vector3.Dot(movement, uphillDirection) > 0.1f;

                if (movingUphill)
                {
                    // Push slightly upward and forward to help the player climb.
                    Vector3 climbAssistDirection = (movement + Vector3.up * 0.35f).normalized;
                    rb.AddForce(climbAssistDirection * 15f, ForceMode.Acceleration);
                }
            }
        }

        // Apply movement to the Rigidbody
        Vector3 velocity = rb.linearVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.linearVelocity = velocity;

        // If we aren't moving and are on the ground, stop velocity so we don't slide
        if (isGrounded && moveHorizontal == 0 && moveForward == 0)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void Jump()
    {
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); // Initial burst for the jump
    }

    void ApplyJumpPhysics()
    {
        if (rb.linearVelocity.y < 0)
        {
            // Falling: Apply fall multiplier to make descent faster
            rb.linearVelocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        } // Rising
        else if (rb.linearVelocity.y > 0)
        {
            // Rising: Change multiplier to make player reach peak of jump faster
            rb.linearVelocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }
}

