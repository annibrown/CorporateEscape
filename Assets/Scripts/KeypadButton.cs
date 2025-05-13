using UnityEngine;
using System.Collections.Generic;

public class KeypadButton : MonoBehaviour
{
    public int buttonValue;
    public Keypad keypad;
    
    public void OnClick()
    {
        keypad.RegisterButtonClick(buttonValue);
    }
}