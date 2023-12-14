using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Not : MonoBehaviour
{
    [SerializeField]
    GameObject locic;
    [SerializeField]
    GameObject input1;
    public bool output;
    private bool _inputbool1 = false;

    void Update()
    {
        if (input1.TryGetComponent<PressingController>(out PressingController pressingControllerComponent))
        {
            if (pressingControllerComponent.activateButton)
            {
                _inputbool1 = !_inputbool1;
            }
        }
        else if (input1.TryGetComponent<Xor>(out Xor xorComponent))
        {
            if (xorComponent.output)
            {
                _inputbool1 = true;
            }
            else if (!xorComponent.output)
            {
                _inputbool1 = false;
            }
        }
        else if (input1.TryGetComponent<And>(out And andComponent))
        {
            if (andComponent.output)
            {
                _inputbool1 = true;   
            }
            else if (!andComponent.output)
            {
                _inputbool1 = false;
            }
        }
        else if (input1.TryGetComponent<Or>(out Or orComponent))
        {
            if (orComponent.output)
            {
                _inputbool1 = true;
            }
            else if (!orComponent.output)
            {
                _inputbool1 = false;
            }
        }
        else if (input1.TryGetComponent<Not>(out Not notComponent))
        {
            if (notComponent.output)
            {
                _inputbool1 = true;
            }
            else if (!notComponent.output)
            {
                _inputbool1 = false;
            }
        }
        else if (input1.TryGetComponent<Nor>(out Nor norComponent))
        {
            if (norComponent.output)
            {
                _inputbool1 = true;
            }
            else if (!norComponent.output)
            {
                _inputbool1 = false;
            }
        }
        else if (input1.TryGetComponent<Nand>(out Nand nandComponent))
        {
            if (nandComponent.output)
            {
                _inputbool1 = true;
            }
            else if (!nandComponent.output)
            {
                _inputbool1 = false;
            }
        }
        else if (input1.TryGetComponent<Xnor>(out Xnor xnorComponent))
        {
            if (xnorComponent.output)
            {
                _inputbool1 = true;
            }
            else if (!xnorComponent.output)
            {
                _inputbool1 = false;
            }
        }
        else
        {
            print("connect input 1");
        }
        if (locic.GetComponent<BasicLogic>().Not(_inputbool1))
        {
            output = true;
        }
        else
        {
            output = false;
        }
    }
}
