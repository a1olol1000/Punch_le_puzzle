using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And : MonoBehaviour
{
    [SerializeField]
    GameObject locic;
    [SerializeField]
    GameObject input1;
    [SerializeField]
    GameObject input2;
    public bool output;
    private bool _inputbool1 = false;
    private bool _inputbool2 = false;
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
        if (input2.TryGetComponent<PressingController>(out PressingController pressingControllerComponent2))
        {
            if (pressingControllerComponent2.activateButton)
            {
                _inputbool2 = !_inputbool2;
            }
        }
        else if (input2.TryGetComponent<Xor>(out Xor xorComponent))
        {
            if (xorComponent.output)
            {
                _inputbool2 = true;
            }
            else if (!xorComponent.output)
            {
                _inputbool2 = false;
            }
        }
        else if (input2.TryGetComponent<And>(out And andComponent))
        {
            if (andComponent.output)
            {
                _inputbool2 = true;   
            }
            else if (!andComponent.output)
            {
                _inputbool2 = false;
            }
        }
        else if (input2.TryGetComponent<Or>(out Or orComponent))
        {
            if (orComponent.output)
            {
                _inputbool2 = true;
            }
            else if (!orComponent.output)
            {
                _inputbool2 = false;
            }
        }
        else if (input2.TryGetComponent<Not>(out Not notComponent))
        {
            if (notComponent.output)
            {
                _inputbool2 = true;
            }
            else if (!notComponent.output)
            {
                _inputbool2 = false;
            }
        }
        else if (input2.TryGetComponent<Nor>(out Nor norComponent))
        {
            if (norComponent.output)
            {
                _inputbool2 = true;
            }
            else if (!norComponent.output)
            {
                _inputbool2 = false;
            }
        }
        else if (input2.TryGetComponent<Nand>(out Nand nandComponent))
        {
            if (nandComponent.output)
            {
                _inputbool2 = true;
            }
            else if (!nandComponent.output)
            {
                _inputbool2 = false;
            }
        }
        else if (input2.TryGetComponent<Xnor>(out Xnor xnorComponent))
        {
            if (xnorComponent.output)
            {
                _inputbool2 = true;
            }
            else if (!xnorComponent.output)
            {
                _inputbool2 = false;
            }
        }
        else
        {
            print("connect input 2");
        }
        if (locic.GetComponent<BasicLogic>().And(_inputbool1,_inputbool2))
        {
            output = true;
        }
        else
        {
            output = false;
        }
    }
}
