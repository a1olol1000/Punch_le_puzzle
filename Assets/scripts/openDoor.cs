using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class openDoor : MonoBehaviour
{
    [SerializeField]
    GameObject open;
    [SerializeField]
    Transform doorFrame;
    [SerializeField]
    public float openAngle = 90.0f; // The angle by which the door should open
    [SerializeField]
    public float openSpeed = 2.0f; // The speed at which the door opens
    [SerializeField]
    public float slideDistanceX = 1.0f; // The distance the door slides to the left
    [SerializeField]
    public float slideDistanceY = 1.0f; // The distance the door slides along the z-axis
    [SerializeField]
    public bool isOpen = true;
    private Vector3 initialPosition;
    private Vector3 openPosition;
    private Vector3 _scale;
    private Vector3 scaleFrame;
    private void Awake() 
    {
        scaleFrame = doorFrame.lossyScale;
        _scale = transform.localScale;
        _scale.x = _scale.x * scaleFrame.x;
        _scale.y = _scale.y * scaleFrame.y;
        _scale.z = _scale.z * scaleFrame.z;
    }
    void Start()
    {
        slideDistanceX = slideDistanceX * _scale.x;
        slideDistanceY = slideDistanceY * _scale.y;
        initialPosition = transform.position;
        openPosition = transform.position + transform.forward * slideDistanceX; // Slide to the left
        openPosition = transform.position + transform.forward * slideDistanceY + transform.right * slideDistanceX; // Slide forward and to the right
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
        if (open.GetComponent<Xor>().output||open.GetComponent<And>().output)
        {
            isOpen=true;
        }
        else if (!open.GetComponent<Xor>().output||!open.GetComponent<And>().output)
        {
            isOpen=false;
        }
    }

    // You can add a method to toggle the door open/close
    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
    
}
