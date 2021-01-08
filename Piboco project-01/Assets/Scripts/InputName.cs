using TMPro;
using System;
using UnityEngine;

public class InputName : MonoBehaviour
{
    //Variables
    public TMP_Text enterNameVar;  // text name for user
    public TMP_Text isYourNameConfirmName;  // confirmation of name text

    TouchScreenKeyboard keyboard;  // keyboard variable

    public GameObject pageMover;  // gameobject that holds the pages, the user can move
    public GameObject confirmNameBox;  // confirmation box pops up asking the user if they have inputted the correct name
    GameObject[] userName;

    // unitys start function
    private void Start()
    {
        userName = GameObject.FindGameObjectsWithTag("Name");

    }


    // unitys update function
    void Update()
    {
        if (userName.Length >= 0)
        {
            // FIND ALL TMP_Text COMPONENTS AND REPLACE 'NAME' IN THEM TO THE USER'S ENTERED NAME
            foreach (GameObject name in userName)
            {
                name.GetComponent<TextMeshProUGUI>().text = name.GetComponent<TextMeshProUGUI>().text.Replace("Name", enterNameVar.text);
                name.GetComponent<TextMeshProUGUI>().text = name.GetComponent<TextMeshProUGUI>().text.Replace("Names", enterNameVar.text + "s");
                Debug.Log("CHECK name change start " + userName.Length);
            }
        }

        try
        {
            if (keyboard.active)  // check to see if the keyboard is active
            {
                enterNameVar.text = keyboard.text;  // apply whatever is inputted into the keyboard to the 'name' variable
            }

            if (keyboard.status == TouchScreenKeyboard.Status.Done)
            {
                confirmNameBox.SetActive(true);
                
            }
            else { confirmNameBox.SetActive(false); }
        }
        catch (NullReferenceException) { }
    }

    // tap / press screen space to enter your name // prompt keyboard
    public void ClickToTypeName()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        Debug.Log("Touch to enter name");
    }

    // Attached to the yes confirmation button , continues to next page
    public void YesConfirmNameButton()
    {
        pageMover.GetComponent<Animator>().SetTrigger("canGoToTitlePage");
        confirmNameBox.SetActive(false);
        Debug.Log("YEs confirm name _ turn to next page(TITLE)");
    }

    // Attached to the no confirmation button, gives the user a chance to change their name
    public void NoConfirmNameButton()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        confirmNameBox.SetActive(false);
        Debug.Log("Not my name return to keyboard_ turn to next page(TITLE)");
    }
}
