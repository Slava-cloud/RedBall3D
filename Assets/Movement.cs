using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public DirectionPointer directionPointer;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded;

    public Vector2 moveInput;
    public LayerMask groundFilter;

    void ReadInput_Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            MakeJump();
        }
    }
    void MakeJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
     
    }
    void CheckGround_FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 0.1f ,0) , 0.5f, groundFilter);
    }

    void Move_FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = directionPointer.cameraObject.transform.TransformDirection(moveDirection);
        moveDirection.y = 0; // Keep the movement on the XZ plane
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.VelocityChange);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput_Update();
    }
    void FixedUpdate()
    {   CheckGround_FixedUpdate();
        Move_FixedUpdate();
    }
}
 