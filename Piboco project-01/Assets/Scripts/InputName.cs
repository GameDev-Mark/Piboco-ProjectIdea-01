using TMPro;
using System;
using UnityEngine;

public class InputName : MonoBehaviour
{
    //Variables
    public TMP_Text enterNameVar;  // text name for user
    private TouchScreenKeyboard keyboard;  // keyboard variable


    // unitys update function
    private void Update()
    {   
        try
        {
            if (keyboard.active)  // check to see if the keyboard is active
            {
                enterNameVar.text = keyboard.text;  // apply whatever is inputted into the keyboard to the 'name' variable
            }
        }
        catch (NullReferenceException) { }
    }

    // tap / press screen space to enter your name // prompt keyboard
    public void ClickToTypeName()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        Debug.Log("Mouse clicked ");
    }
}
