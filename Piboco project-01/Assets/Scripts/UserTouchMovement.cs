using UnityEngine;

public class UserTouchMovement : MonoBehaviour
{
    public GameObject lastPage;  // last page gameobject
    public GameObject titlePage;  // first page gameobject

    public RectTransform pagerMoverRectT;  // parent object of all pages

    float scrollSpeed;  // speed of the scrolling 

    bool _firstPageBlocker;  // boolean trigger to see if the user is at first page 
    bool _lastPageBlocker; // boolean trigger to see if the user is at last page 


    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = 18f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FIRST PAGE is " + _firstPageBlocker);
        Debug.Log("LAST PAGE is " + _lastPageBlocker);
        NextPages();

        if (titlePage.transform.position.x > Screen.width / 2)
        {
            _firstPageBlocker = true;
        }

        if (lastPage.transform.position.x < Screen.width / 2)
        {
            _lastPageBlocker = true;
        }
    }

    // tap and hold left or right side of the screen to go back or forwards on the pages
    public void NextPages()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                pagerMoverRectT.Translate(Vector3.right * scrollSpeed);
                _lastPageBlocker = false;
                Debug.Log("Touch left side of screen to move left (BACKWARDS)");
            }
            else if (Input.mousePosition.x > Screen.width / 2)
            {
                pagerMoverRectT.Translate(Vector3.left * scrollSpeed);
                _firstPageBlocker = false;
                Debug.Log("Touch right side of screen to move right (FORWARDS)");
            }

            if (_firstPageBlocker == true) // stops the scrolling at the first page 
            {
                pagerMoverRectT.anchoredPosition = new Vector2(-800, pagerMoverRectT.anchoredPosition.y);
            }

            if (_lastPageBlocker == true) // stops the scrolling at the last page
            {
                pagerMoverRectT.anchoredPosition = new Vector2(-5600f, pagerMoverRectT.anchoredPosition.y);
            }
        }
    }
}
