using UnityEngine;

public class GameCon : MonoBehaviour
{
    //Variables
    public GameObject lastPage;  // last page gameobject

    public RectTransform pagerMoverRectT;  // parent object of all pages
    public RectTransform namePage;
    public RectTransform _titlePage;
    public RectTransform _page01;
    public RectTransform _page02;
    public RectTransform _page03;
    public RectTransform _page04;
    public RectTransform _page05;
    public RectTransform _page06;

    float scrollSpeed;

    bool _firstPageBlocker;  // boolean trigger to see if the user is at first page 
    bool _lastPageBlocker; // boolean trigger to see if the user is at last page 


    // unitys start function
    private void Start()
    {
        scrollSpeed = 18f;

        _titlePage.anchoredPosition = new Vector2(800f, _titlePage.anchoredPosition.y);
        _page01.anchoredPosition = new Vector2(1600f, _page01.anchoredPosition.y);
        _page02.anchoredPosition = new Vector2(2400f, _page02.anchoredPosition.y);
        _page03.anchoredPosition = new Vector2(3200f, _page03.anchoredPosition.y);
        _page04.anchoredPosition = new Vector2(4000f, _page04.anchoredPosition.y);
        _page05.anchoredPosition = new Vector2(4800f, _page05.anchoredPosition.y);
        _page06.anchoredPosition = new Vector2(5600f, _page06.anchoredPosition.y);
    }

    // unitys update function
    void Update()
    {
        NextPages();

        if (pagerMoverRectT.anchoredPosition.x > Screen.width / 100)
        {
            _firstPageBlocker = true;
        }

        if (lastPage.transform.position.x < Screen.width / 2)
        {
            _lastPageBlocker = true;
        }
    }

    // tap and hold left or right side of the screen to go back or forwards on the pages
    void NextPages()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                pagerMoverRectT.Translate(Vector3.right * scrollSpeed);
                _lastPageBlocker = false;
                //Debug.Log("Touch left side of screen to move left (BACKWARDS)");
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                pagerMoverRectT.Translate(Vector3.left * scrollSpeed);
                _firstPageBlocker = false;
                //Debug.Log("Touch right side of screen to move right (FORWARDS)");
            }

            if (_firstPageBlocker == true) // stops the scrolling at the first page 
            {
                pagerMoverRectT.anchoredPosition = Vector3.zero;
            }

            if (_lastPageBlocker == true) // stops the scrolling at the last page
            {
                pagerMoverRectT.anchoredPosition = new Vector3(-5600f, pagerMoverRectT.anchoredPosition.y);
            }
        }
    }
}
