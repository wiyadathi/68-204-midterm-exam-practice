using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // forward/back speed
    public float rotateSpeed = 120f;  // turn speed
    public float jumpForce = 6f;      // jump strength

    Rigidbody rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ----- ROTATE LEFT / RIGHT -----
        float turn = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            turn = -1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            turn = 1f;

        transform.Rotate(Vector3.up * turn * rotateSpeed * Time.deltaTime);

        // ----- JUMP -----
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // instant upward push
        }
    }

    void FixedUpdate()
    {
        // ----- MOVE FORWARD / BACKWARD -----
        float move = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            move = 1f;

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            move = -1f;

        Vector3 forwardMove = transform.forward * move * moveSpeed;

        // keep current Y velocity (gravity)
        rb.linearVelocity = new Vector3(
            forwardMove.x,
            rb.linearVelocity.y,
            forwardMove.z
        );
    }

    // ----- GROUND CHECK -----
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
