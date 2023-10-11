using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMover : MonoBehaviour
{
    private inputManager inputManager;
    float upp ;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = inputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.GetKeyDown(KeybindingActions.Jump))
        {
            upp ++;
        }
        
        Vector3 move = new Vector3(0, 0, upp) * Time.deltaTime;
        transform.Translate(move);
    }
}
