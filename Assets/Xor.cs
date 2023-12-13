using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xor : MonoBehaviour
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
        if (input1.GetComponent<PressingController>().activateButton)
        {
            _inputbool1 = !_inputbool1;
        }
        if (input2.GetComponent<PressingController>().activateButton)
        {
            _inputbool2 = !_inputbool2;
        }
        if (locic.GetComponent<BasicLogic>().Xor(_inputbool1,_inputbool2))
        {
            output = true;
        }
        else
        {
            output = false;
        }
    }
}
