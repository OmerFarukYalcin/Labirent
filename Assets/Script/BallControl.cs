using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Reference to the Rigidbody component of the ball.
    private Rigidbody rb;

    // Movement speed of the ball.
    [SerializeField] private float velocity = 2f;

    // Vector to store movement input.
    private Vector3 movementVector;

    private void Start()
    {
        // Cache the Rigidbody component for physics-based movement.
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // If the game is not over, allow the ball to move.
        // Otherwise, stop all ball velocities (movement and rotation).
        if (!GameManager.instance.GameOver)
        {
            Move();
        }
        else
        {
            StopVelocitiesOfBall();
        }
    }

    // Moves the ball based on player input from the horizontal and vertical axes.
    private void Move()
    {
        // Get input from the horizontal (X) and vertical (Z) axes.
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

        // Apply movement force to the ball.
        rb.AddForce(CalculateMovementVector(movementVector.z, movementVector.x, velocity));
    }

    // Stops the ball's velocity and angular velocity (rotation).
    private void StopVelocitiesOfBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    // Calculates the movement vector based on input and movement speed.
    private Vector3 CalculateMovementVector(float _horizontal, float _vertical, float _moveSpeed)
    {
        // Calculate movement on the X and Z axes with given velocity.
        float x = _horizontal * velocity;
        float z = _vertical * -velocity;  // Inverted Z for correct movement.

        return new Vector3(x, 0f, z);
    }
}
