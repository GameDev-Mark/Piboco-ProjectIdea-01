using UnityEngine;

public class UserTouchMovement : MonoBehaviour
{
    public GameObject lastPage;  // last page gameobject
    public GameObject titlePage;  // first page gameobject

    public RectTransform pagerMoverRectT;  // parent object of all pages

    float scrollSpeed;  // speed of the scrolling 

    bool _firstPageBlocker;  // boolean trigger to see if the user is at first page 
    bool _lastPageBlocker; // boolean trigger to see if the user is at last page 


    // unitys start function
    void Start()
    {
        scrollSpeed = 18f;
    }

    // unitys update function
    void Update()
    {
        NextPages();

        if (titlePage.transform.position.x > Screen.width / 2) // collecting info if the first page comes into screen view
        {
            _firstPageBlocker = true;
        }

        if (lastPage.transform.position.x < Screen.width / 2) // collecting info if the last page comes into screen view
        {
            _lastPageBlocker = true;
        }
    }

    // tap and hold left or right side of the screen to go back or forwards on the pages
    public void NextPages()
    {
        if (Input.GetMouseButton(0)) // scrolls the pages forwards or backwards depending on if the user is clicking the left side or the right side of the screen
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

            if (_firstPageBlocker == true) // blocks scrolling past the first page
            {
                pagerMoverRectT.anchoredPosition = new Vector2(-800, pagerMoverRectT.anchoredPosition.y);
            }

            if (_lastPageBlocker == true) // blocks scrolling past the last page
            {
                pagerMoverRectT.anchoredPosition = new Vector2(-5600f, pagerMoverRectT.anchoredPosition.y);
            }
        }
    }
}
