using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    private float moveSpeed;
    private float slowSpeed = 1f;
    private float fastSpeed = 6f;
    private float baseSpeed = 4f;
    private float jumpForce = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        Vector2 inputVector = new Vector2(0, 0);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = slowSpeed;
        } else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = fastSpeed;
        }
        else
        {
            moveSpeed = baseSpeed;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }
        
        inputVector = inputVector.normalized;

        Vector3 moveDirection = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
    }
}