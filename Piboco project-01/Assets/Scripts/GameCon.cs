using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCon : MonoBehaviour
{
    //Variables
    public RectTransform[] _pages = new RectTransform[8];  // all transforms of the pages of the book
    public Image[] _items = new Image[6];  // all images of the food

    public AudioClip popSFX;  // pop sfx attached to interactables

    // unitys start function
    void Start()
    {
        // anchoring all pages next to each other 
        _pages[0].anchoredPosition = new Vector2(_pages[0].anchoredPosition.x, _pages[0].anchoredPosition.y);
        _pages[1].anchoredPosition = new Vector2(800f, _pages[1].anchoredPosition.y);
        _pages[2].anchoredPosition = new Vector2(1600f, _pages[2].anchoredPosition.y);
        _pages[3].anchoredPosition = new Vector2(2400f, _pages[3].anchoredPosition.y);
        _pages[4].anchoredPosition = new Vector2(3200f, _pages[4].anchoredPosition.y);
        _pages[5].anchoredPosition = new Vector2(4000f, _pages[5].anchoredPosition.y);
        _pages[6].anchoredPosition = new Vector2(4800f, _pages[6].anchoredPosition.y);
        _pages[7].anchoredPosition = new Vector2(5600f, _pages[7].anchoredPosition.y);

        GetComponent<UserTouchMovement>().enabled = false; // disabling scrolling at the start 
    }

    // attached to replay button, reload scene to replay the book from the beginning
    public void Replaybutton()
    {
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position);
        SceneManager.LoadScene(0);
        //Debug.Log("Replay book");
    }

    // event trigger attached to the buttons, stops the scrolling movement when hovering over buttons
    public void DisableScrolling()
    {
        GetComponent<UserTouchMovement>().enabled = false;
        //Debug.Log("scrolling DISABLED");
    }

    // event trigger attached to the buttons, re enables the scrolling movement when exiting the buttons
    public void ReEnableScrolling()
    {
        GetComponent<UserTouchMovement>().enabled = true;
        //Debug.Log("scrolling RE-ENABLED");
    }

    // clickable button for the carrot image, plays a sound, image fades out
    public void CarrotImage()
    {
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position);
        _items[0].CrossFadeAlpha(0, 4f, true);
        //Debug.Log("carrot clicked");
    }

    // clickable button for the potato image, plays a sound, image fades out
    public void PotatoImage()
    {
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position);
        _items[1].CrossFadeAlpha(0, 4f, true);
        //Debug.Log("potato clicked");
    }

    // clickable button for the onion image, plays a sound, image fades out
    public void OnionImage()
    {
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position);
        _items[2].CrossFadeAlpha(0, 4f, true);
        //Debug.Log("Onion clicked");
    }

    // clickable button for the butter image, plays a sound, image fades out
    public void ButterImage()
    {
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position);
        _items[3].CrossFadeAlpha(0, 4f, true);
        //Debug.Log("butter clicked");
    }

    // clickable button for the milk image, plays a sound, image fades out
    public void MilkImage()
    {
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position);
        _items[4].CrossFadeAlpha(0, 4f, true);
        //Debug.Log("milk clicked");
    }

    // clickable button for the bread image, plays a sound, image fades out
    public void BreadImage()
    {
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position);
        _items[5].CrossFadeAlpha(0, 4f, true);
        //Debug.Log("bread clicked");
    }
}
