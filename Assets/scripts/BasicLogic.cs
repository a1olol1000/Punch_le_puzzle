using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicLogic : MonoBehaviour
{
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
   public bool Or(bool a, bool b)
   {
        bool processedInput = false;
        if (a||b)
        {
            processedInput = true;
        }
        return processedInput;
   }
   public bool Xor(bool a, bool b)
   {
        bool processedInput = false;
        if (Or(a,b))
        {
            processedInput = true;
            if (And(a,b))
            {
                processedInput = false;
            }
        }
        return processedInput;
   }
    public bool Nor(bool a,bool b)
    { 
        return Not(Or(a,b));
    }
    
}
