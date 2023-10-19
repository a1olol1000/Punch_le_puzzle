using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;
using System.ComponentModel;

public class characterMover : MonoBehaviour
{
    [SerializeField]
    Transform facecamera;
    [SerializeField]
    GameObject faceCamera;
    int xposm=0;
    int yposm=0;
    int framecurent=0;
    Vector3 mosepotisionDelta;
    Vector3 rotate;
    Vector3 mouseSavePosition1;
    Vector3 mousePosition2;
    [SerializeField]
    float spinspeed = 1f;
        [SerializeField]
    float tiltspeed = 10f;
    [SerializeField]
    float jumpForze = 100f;
    [SerializeField]
    float walkSpeed = 7.5f;
    [SerializeField]
    float runSpeed = 10f;
    float run = 0f;
    private inputManager inputManager;
    Rigidbody riibody;
    float upp ;
    float horisontal;
    float vertical;
    // Start is called before the first frame update
    void Awake() 
    {
        riibody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        mousePosition2 = Input.mousePosition;
        inputManager = inputManager.instance;
        xposm = (int)mousePosition2.x;
        yposm = (int)mousePosition2.y;
    }

    // Update is called once per frame
    void Update()
    {
        int xPos = xposm, yPos = yposm;

        
        if (inputManager.GetKeyDown(KeybindingActions.Jump))
        {
            riibody.AddForce(Vector3.up * jumpForze);
        }
        float walk = walkSpeed;
        if (inputManager.GetKey(KeybindingActions.Run))
        {
            run = runSpeed;
        }
        else if (!inputManager.GetKey(KeybindingActions.Run))
        {
            run = 0f;
        }
        if (inputManager.GetKey(KeybindingActions.Walkforward)&&inputManager.GetKey(KeybindingActions.Walkbakward))
        {
            vertical = 0;
        }
        else if (inputManager.GetKey(KeybindingActions.Walkforward))
        {
            vertical = 1;
        }
        else if (inputManager.GetKey(KeybindingActions.Walkbakward))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }
        if (inputManager.GetKey(KeybindingActions.StafeLeft)&&inputManager.GetKey(KeybindingActions.StrafeRight))
        {
            horisontal = 0;
        }
        else if (inputManager.GetKey(KeybindingActions.StafeLeft))
        {
            horisontal = 1;
        }
        else if (inputManager.GetKey(KeybindingActions.StrafeRight))
        {
            horisontal = -1;
        }
        else
        {
            horisontal = 0;
        }
        walk = walk + run;
        Vector3 move = new Vector3(-vertical, horisontal, upp);
        move.Normalize();
        move = move * walk * Time.deltaTime;
        transform.Translate(move);
        transform.Rotate(0,0,rotate.z*spinspeed*Time.deltaTime);
        faceCamera.transform.Rotate(rotate.y*tiltspeed*Time.deltaTime,0,0);
        rotate.x = 0;
        rotate.y=0;
        rotate.z=0;
        if (inputManager.GetKey(KeybindingActions.Interackt))
        {
            mouseSavePosition1 = Input.mousePosition;
            mosepotisionDelta= mouseSavePosition1 - mousePosition2;
            if (Input.GetAxis("Mouse X")>0)
            {
                rotate.z = mosepotisionDelta.x;
            }
            else if (Input.GetAxis("Mouse X")<0)
            {
                rotate.z = mosepotisionDelta.x;
            }
            else 
            {
                rotate.z = 0;
            }
            if (Input.GetAxis("Mouse Y")>0)
            {
                rotate.y = -mosepotisionDelta.y;
            }
            else if (Input.GetAxis("Mouse Y")<0)
            {
                rotate.y = -mosepotisionDelta.y;
            }
            else 
            {
                rotate.y = 0;
            }
            SetCursorPos(xPos,yPos);
        }  
        
    }
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

}