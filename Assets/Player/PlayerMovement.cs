using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start() => rb = GetComponent<Rigidbody>();

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v).normalized;
        rb.MovePosition(rb.position + dir * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionStay(Collision other)
    {
        if ((groundLayer.value & (1 << other.gameObject.layer)) > 0)
            isGrounded = true;
    }

    void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}