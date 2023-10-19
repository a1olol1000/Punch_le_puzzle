using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed as needed
    public float maxHeight = 10.0f; // Set the maximum height the elevator can reach
    private bool movingUp = true;

    void Update()
    {
        // Check if the elevator is within its allowed range
        if (movingUp && transform.position.y < maxHeight)
        {
            // Move the elevator up
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            // Change direction when it reaches the max height or other conditions as needed
            movingUp = false;

            // You can implement logic here for moving the elevator down.
        }
    }
}
