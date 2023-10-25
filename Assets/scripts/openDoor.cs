using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    [SerializeField]
    public float openAngle = 90.0f; // The angle by which the door should open
    [SerializeField]
    public float openSpeed = 2.0f; // The speed at which the door opens
    [SerializeField]
    public float slideDistanceX = 1.0f; // The distance the door slides to the left
    [SerializeField]
    public float slideDistanceZ = 1.0f; // The distance the door slides along the z-axis
    [SerializeField]
    public bool isOpen = true;
    private Vector3 initialPosition;
    private Vector3 openPosition;

    void Start()
    {
        initialPosition = transform.position;
        openPosition = transform.position + transform.forward * slideDistanceX; // Slide to the left
        openPosition = transform.position + transform.forward * slideDistanceZ + transform.right * slideDistanceX; // Slide forward and to the right

    }

    void Update()
    {
        if (isOpen)
        {
            // Rotate the door towards the open position
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, openAngle, 0), Time.deltaTime * openSpeed);

            // Move the door towards the open position
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * openSpeed);
        }
        else
        {
            // Rotate the door back to its initial position
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * openSpeed);

            // Move the door back to its initial position
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * openSpeed);
        }
    }

    // You can add a method to toggle the door open/close
    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
    
}




