using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private float speed;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    [SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        speed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // if (Input.GetKey(KeyCode.A))
        //     rb.AddForce((Vector3.left+Vector3.forward)*forceOver2);
        // if (Input.GetKey(KeyCode.D))
        //     rb.AddForce((Vector3.right-Vector3.forward)*forceOver2);
        // if (Input.GetKey(KeyCode.W))
        //     rb.AddForce((Vector3.forward+Vector3.right)*forceOver2);
        // if (Input.GetKey(KeyCode.S))
        //     rb.AddForce((-Vector3.forward-Vector3.right)*forceOver2);
        // Get H and V input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(vertical, 0f, -horizontal).normalized;
        // Make Isometric
        direction = Quaternion.Euler(0f, -45f, 0f) * direction;

        // Move the player
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            // Smooth the rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                                                ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            controller.Move(direction * speed * Time.deltaTime);
            // also tried
            // trandform.position += direction * speed * Time.deltaTime;

            Debug.Log("Y: " + transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 375);
        }
    }
}
