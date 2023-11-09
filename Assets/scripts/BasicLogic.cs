using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicLogic : MonoBehaviour
{
    public static BasicLogic instance;
    public bool Not(bool a)
   {
    bool processedInput = !a;
    return processedInput;
   }
    public bool And(bool a,bool b)
   {
    bool processedInput = false;
    if (a&&b)
    {
        processedInput = true;
    }
    return processedInput;
   }
    public bool Or(bool a,bool b)
   {
        bool processedInput = false;
        if (a||b)
        {
            processedInput = true;
        }
        return processedInput;
   }
    public bool Nor(bool a,bool b)
    { 
        return Not(Or(a,b));
    }
    public bool Nand(bool a,bool b)
    {
        return Not(And(a,b));
    }
    public bool Xor(bool a, bool b)
   {
        return And(Nand(a,b),Or(a,b));
   }
    public bool Xnor(bool a,bool b)
    {
        return Not(Xor(a,b));
    }


}