using TMPro;
using System;
using UnityEngine;

public class InputName : MonoBehaviour
{
    //Variables
    public TMP_Text enterNameVar;  // text name for user
    public TMP_Text isYourNameConfirmName;  // confirmation of name text
    

    public RectTransform pageMoverAll;  // transform that holds the pages, the user can move

    /*TouchScreenKeyboard keyboard;*/  // ANDROID AND IPHONE keyboard //
    public GameObject _keyboardPC;  // PC keyboard //

    /*bool _isFinshedName; */ // ANDROID AND IPHONE keyboard boolean stating when name has been entered in by the user // 

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
            // MOBILE ANDROID AND IPHONE KEYBOARD PROMPTING //
            //if (keyboard.active)  // check to see if the keyboard is active
            //{
            //    enterNameVar.text = keyboard.text;  // apply whatever is inputted into the keyboard to the 'name' variable
            //    isYourNameConfirmName.text = "Is " + keyboard.text + " your name?";
            //}

            //if (keyboard.status == TouchScreenKeyboard.Status.Done && _isFinshedName == false)
            //{
            //    confirmNameBox.SetActive(true);
            //}
            //else if (keyboard.status == TouchScreenKeyboard.Status.Done && _isFinshedName == true)
            //{
            //    confirmNameBox.SetActive(false);
            //}

            // PC KEYBOARD PROMPTING // 
            if (_keyboardPC.gameObject.activeInHierarchy)  // check to see if the keyboard is active
            {
                enterNameVar.text = _keyboardPC.GetComponentInChildren<TMP_InputField>().text;  // apply whatever is inputted into the keyboard to the 'name' variable
                isYourNameConfirmName.text = "Is " + enterNameVar.text + " your name?";
            }
        }
        catch (NullReferenceException) { }
    }

    // attached to the enter button , confirm name at the start // PC KEYBOARD //
    public void EnterButton()
    {
        _keyboardPC.gameObject.SetActive(false);
        confirmNameBox.SetActive(true);
    }

    // attached event to the name button , tap / press screen space to enter your name , prompt keyboard
    public void ClickToTypeName()
    {
        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);  // ANDROID / IPHONE KEYBOARD PROMPT //

        _keyboardPC.gameObject.SetActive(true);  // activate input text field as keyboard / PC KEYBOARD //
        AudioSource.PlayClipAtPoint(GetComponent<GameCon>().popSFX, Camera.main.transform.position);
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
                //Debug.Log("CHECK name change start " + userName.Length);
            }
        }

        pageMoverAll.anchoredPosition = new Vector2(-800f, pageMoverAll.anchoredPosition.y);
        GetComponent<UserTouchMovement>().enabled = true;
        //_isFinshedName = true;  // bool for android and iphone keyboard //
        confirmNameBox.SetActive(false);
        AudioSource.PlayClipAtPoint(GetComponent<GameCon>().popSFX, Camera.main.transform.position);
        //Debug.Log("YEs confirm name _ turn to next page(TITLE)");
    }

    // Attached to the no confirmation button, gives the user a chance to change their name
    public void NoConfirmNameButton()
    {
        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);  // ANDROID / IPHONE KEYBOARD PROMPT // 

        _keyboardPC.gameObject.SetActive(true);  // activate input text field as keyboard // PC KEYBOARD //
        confirmNameBox.SetActive(false);
        AudioSource.PlayClipAtPoint(GetComponent<GameCon>().popSFX, Camera.main.transform.position);
        //Debug.Log("Not my name return to keyboard_ turn to next page(TITLE)");
    }
}
