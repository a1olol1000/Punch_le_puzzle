using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class keyBindings : ScriptableObject
{
    [System.Serializable]
    public class KeybindingCheck
    {
        
        public KeybindingActions keybindingActions;
        public KeyCode keyCode;
    }
    public KeybindingCheck[] keybindingCheck;
}
