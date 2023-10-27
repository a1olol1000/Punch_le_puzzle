using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    [SerializeField]
    GameObject elevatorButton;
    public float speed = 2.0f; // Adjust the speed as needed
    public float maxHeight = 10.0f; // Set the maximum height the elevator can reach
    public float minHeight = 0f;
    public bool movingUp = true;
    public static ElevatorMove instance;

    void Update()
    {
        // Check if the elevator is within its allowed range
        if (movingUp && transform.position.y < maxHeight)
        {
            // Move the elevator up
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        else if (!movingUp&&transform.position.y >minHeight)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
    public void ActivateElevator()
    {
        movingUp=!movingUp;
    }
}
