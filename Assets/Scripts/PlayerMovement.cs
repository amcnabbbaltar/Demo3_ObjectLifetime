using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Movement relative to where the player is facing
        Vector3 moveDirection =
            transform.right * xInput +
            transform.forward * zInput;

        moveDirection.Normalize();

        rb.velocity = new Vector3(
            moveDirection.x * speed,
            rb.velocity.y,
            moveDirection.z * speed
        );
    }
}
