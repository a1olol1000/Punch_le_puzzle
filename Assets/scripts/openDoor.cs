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
        // print("Open: " + open);
        // print("Xor: " + open.GetComponent<Xor>());

        if (open.TryGetComponent<Xor>(out Xor xorComponent))
        {
            if (xorComponent.output)
            {
                isOpen = true;
            }
            else if (!xorComponent.output)
            {
                isOpen = false;
            }
        }
        else if (open.TryGetComponent<And>(out And andComponent))
        {
            if (andComponent.output)
            {
                isOpen = true;   
            }
            else if (!andComponent.output)
            {
                isOpen = false;
            }
        }
        else if (open.TryGetComponent<Or>(out Or orComponent))
        {
            if (orComponent.output)
            {
                isOpen = true;
            }
            else if (!orComponent.output)
            {
                isOpen = false;
            }
        }
        else if (open.TryGetComponent<Not>(out Not notComponent))
        {
            if (notComponent.output)
            {
                isOpen = true;
            }
            else if (!notComponent.output)
            {
                isOpen = false;
            }
        }
        else if (open.TryGetComponent<Nor>(out Nor norComponent))
        {
            if (norComponent.output)
            {
                isOpen = true;
            }
            else if (!norComponent.output)
            {
                isOpen = false;
            }
        }
        else if (open.TryGetComponent<Nand>(out Nand nandComponent))
        {
            if (nandComponent.output)
            {
                isOpen = true;
            }
            else if (!nandComponent.output)
            {
                isOpen = false;
            }
        }
        else if (open.TryGetComponent<Xnor>(out Xnor xnorComponent))
        {
            if (xnorComponent.output)
            {
                isOpen = true;
            }
            else if (!xnorComponent.output)
            {
                isOpen = false;
            }
        }
        else
        {
            print("connect input");
        }

        



        
    }

    // You can add a method to toggle the door open/close
    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
    
}
