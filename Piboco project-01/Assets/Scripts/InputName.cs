using TMPro;
using System;
using UnityEngine;

public class InputName : MonoBehaviour
{
    //Variables
    public TMP_Text enterNameVar;  // text name for user
    private TouchScreenKeyboard keyboard;  // keyboard variable
    public GameObject pageMover;

    private void Start()
    {
        
    }

    // unitys update function
    private void Update()
    {   
        try
        {
            if (keyboard.active)  // check to see if the keyboard is active
            {
                enterNameVar.text = keyboard.text;  // apply whatever is inputted into the keyboard to the 'name' variable
            }
            
            if(keyboard.status == TouchScreenKeyboard.Status.Done)
            {
                
                Debug.Log("Done typing name _ turn to next page(TITLE)");
            }
        }
        catch (NullReferenceException) { }
    }

    // tap / press screen space to enter your name // prompt keyboard
    public void ClickToTypeName()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        Debug.Log("Mouse clicked button");
        pageMover.GetComponent<Animator>().SetTrigger("canGoToTitlePage");
    }
}
