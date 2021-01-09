using TMPro;
using System;
using UnityEngine;

public class InputName : MonoBehaviour
{
    //Variables
    public TMP_Text enterNameVar;  // text name for user
    public TMP_Text isYourNameConfirmName;  // confirmation of name text

    public RectTransform pageMoverAll;  // transform that holds the pages, the user can move

    TouchScreenKeyboard keyboard;  // keyboard variable

    bool _isFinshedName;  // boolean stating when name has been entered in by the user

    public GameObject confirmNameBox;  // confirmation box pops up asking the user if they have inputted the correct name
    GameObject[] userName;  // collecting an array of gameobjects and naming them userName


    // unitys start function
    void Start()
    {
        userName = GameObject.FindGameObjectsWithTag("Name");
    }

    // unitys update function
    void Update()
    {
        try
        {
            if (keyboard.active)  // check to see if the keyboard is active
            {
                enterNameVar.text = keyboard.text;  // apply whatever is inputted into the keyboard to the 'name' variable
                isYourNameConfirmName.text = "Is " + keyboard.text + " your name?";
            }

            if (keyboard.status == TouchScreenKeyboard.Status.Done && _isFinshedName == false)
            {
                confirmNameBox.SetActive(true);
            }
            else if (keyboard.status == TouchScreenKeyboard.Status.Done && _isFinshedName == true)
            {
                confirmNameBox.SetActive(false);
            }
        }
        catch (NullReferenceException) { }
    }

    // attached event to the name button , tap / press screen space to enter your name , prompt keyboard
    public void ClickToTypeName()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        //Debug.Log("Touch to enter name");
    }

    // Attached to the yes confirmation button , continues to next page
    public void YesConfirmNameButton()
    {
        if (userName.Length >= 0)
        {
            // FIND ALL TextMeshProUGUI COMPONENTS AND REPLACE 'NAME' IN  THE TEXT TO THE USER'S ENTERED NAME
            foreach (GameObject name in userName)
            {
                name.GetComponent<TextMeshProUGUI>().text = name.GetComponent<TextMeshProUGUI>().text.Replace("Name", enterNameVar.text);
                name.GetComponent<TextMeshProUGUI>().text = name.GetComponent<TextMeshProUGUI>().text.Replace("Names", enterNameVar.text + "s");
                Debug.Log("CHECK name change start " + userName.Length);
            }
        }
        pageMoverAll.anchoredPosition = new Vector2(-800f, pageMoverAll.anchoredPosition.y);
        GetComponent<UserTouchMovement>().enabled = true;
        _isFinshedName = true;
        confirmNameBox.SetActive(false);
        //Debug.Log("YEs confirm name _ turn to next page(TITLE)");
    }

    // Attached to the no confirmation button, gives the user a chance to change their name
    public void NoConfirmNameButton()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        confirmNameBox.SetActive(false);
        //Debug.Log("Not my name return to keyboard_ turn to next page(TITLE)");
    }
}
