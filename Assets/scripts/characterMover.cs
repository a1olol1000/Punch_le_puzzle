using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterMover : MonoBehaviour
{
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
        inputManager = inputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector3 move = new Vector3(-vertical, horisontal, upp) * walk * Time.deltaTime;
        transform.Translate(move);
        
    }
}
