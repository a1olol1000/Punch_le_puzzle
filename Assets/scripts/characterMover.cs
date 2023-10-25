using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data.Common;
using Unity.Content;



public class characterMover : MonoBehaviour
{

    [SerializeField]
    GameObject faceCamera;
    int framecurent=0;
    Vector2 mosepotisionDelta;
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
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        inputManager = inputManager.instance;

    }

    // Update is called once per frame
    void Update()
    {
        mosepotisionDelta.x = Input.GetAxis("Mouse X")*spinspeed;
        mosepotisionDelta.y = Input.GetAxis("Mouse Y")*tiltspeed;
        
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
        transform.Rotate(0,0,mosepotisionDelta.x);
        faceCamera.transform.Rotate(-mosepotisionDelta.y,0,0);
        
        if (inputManager.GetKeyDown(KeybindingActions.SwitchCam))
        {
            CameraManager.instance.ManagerarCam();
            
        }
        
        
    }


}