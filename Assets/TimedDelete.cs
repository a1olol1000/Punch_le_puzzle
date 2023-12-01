using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDelete : MonoBehaviour
{
    [SerializeField]
    int timeTillDie=4;
    // Start is called before the first frame update
    private void Awake() 
    {
        GameObject.Destroy(this,timeTillDie);
    }
}
