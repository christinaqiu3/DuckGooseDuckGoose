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
    public bool isPlayerOne = true;

    // Start is called before the first frame update
    void Awake()
    {
        speed = 10f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = 0f;
        float vertical = 0f;
        Vector3 direction = new Vector3(0f, 0f, 0f);

        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.A))
            {
                horizontal -= 1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                horizontal += 1f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                vertical += 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                vertical -= 1f;
            }
            direction = new Vector3(vertical, 0f, -horizontal).normalized;  
        } else 
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal -= 1f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontal += 1f;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                vertical += 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                vertical -= 1f;
            }
            direction = new Vector3(vertical, 0f, -horizontal).normalized;
        }
        // // Make Isometric
        direction = Quaternion.Euler(0f, -45f, 0f) * direction;

        // Move the player
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg -90f;

            // Smooth the rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                                                ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
            // also tried
            // trandform.position += direction * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 375);
        }
    }
}
