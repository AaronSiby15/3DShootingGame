using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    private float moveSpeed;
    private float slowSpeed = 1f;
    private float fastSpeed = 6f;
    private float baseSpeed = 4f;
    private float jumpForce = 5f;
    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        Vector2 inputVector = Vector2.zero;

        // Adjust movement speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = slowSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = fastSpeed;
            animator.SetTrigger("Sprint");
        }
        else
        {
            moveSpeed = baseSpeed;
        }

        // Movement input & animations
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("Left");
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Right");
        }

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
            animator.SetTrigger("Forward");
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
            animator.SetTrigger("Backward");
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
            animator.SetTrigger("Left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
            animator.SetTrigger("Right");
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) &&
            !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetTrigger("Stop");
        }

        // Normalize input and move
        inputVector = inputVector.normalized;
        Vector3 moveDirection = (transform.forward * inputVector.y + transform.right * inputVector.x).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jumping!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Ground Collision Detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
