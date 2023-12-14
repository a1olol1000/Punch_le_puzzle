using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressingController : MonoBehaviour
{
    [SerializeField]
    GameObject buttonpress;
    public bool activateButton;
    private inputManager inputManager;
    private void Start() 
    {
        inputManager = inputManager.instance;
        print("isntanse");
    }
    private void OnTriggerStay(Collider other) {
        print("coliide");
    if (other.gameObject.tag == "Raycaster")
    {
        print("find");
        if (inputManager.GetKeyDown(KeybindingActions.Interackt))
        {
            print("press");
            activateButton = true;
            Instantiate(buttonpress);
        }
        else
        {
            activateButton = false;
        }
    }
    else
    {
        activateButton = false;
    }
    }
    
}