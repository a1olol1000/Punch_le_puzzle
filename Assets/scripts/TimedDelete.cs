using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDelete : MonoBehaviour
{
    [SerializeField]
    int timeTillDie=4;

    private void Awake() 
    {
        GameObject.Destroy(this.gameObject,timeTillDie);
    }
}
