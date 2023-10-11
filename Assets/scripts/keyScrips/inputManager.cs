using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class inputManager : MonoBehaviour
{
    public static inputManager instance;
    [SerializeField] private keyBindings keyBindings;
    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    public KeyCode GetKeyForAction(KeybindingActions keybindingAction)
    {
        foreach(keyBindings.KeybindingCheck keybindingCheck in keyBindings.keybindingCheck)
        {
            if (keybindingCheck.keybindingActions == keybindingAction)
            {
                return keybindingCheck.keyCode;
            }
        }
        return KeyCode.None;
    }
    public bool GetKeyDown(KeybindingActions key)
    {
        foreach(keyBindings.KeybindingCheck keybindingCheck in keyBindings.keybindingCheck)
        {
            if (keybindingCheck.keybindingActions == key)
            {
                return Input.GetKeyDown(keybindingCheck.keyCode);
            }
        }
        return false;
    }
    public bool GetKey(KeybindingActions key)
    {
        foreach(keyBindings.KeybindingCheck keybindingCheck in keyBindings.keybindingCheck)
        {
            if (keybindingCheck.keybindingActions == key)
            {
                return Input.GetKey(keybindingCheck.keyCode);
            }
        }
        return false;
    }
        public bool GetKeyup(KeybindingActions key)
    {
        foreach(keyBindings.KeybindingCheck keybindingCheck in keyBindings.keybindingCheck)
        {
            if (keybindingCheck.keybindingActions == key)
            {
                return Input.GetKeyUp(keybindingCheck.keyCode);
            }
        }
        return false;
    }
}
