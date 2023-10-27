using System.Collections;
using System.Collections.Generic;
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

}
