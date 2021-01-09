using UnityEngine;

public class GameCon : MonoBehaviour
{
    //Variables
    public RectTransform namePage;
    public RectTransform _titlePage;
    public RectTransform _page01;
    public RectTransform _page02;
    public RectTransform _page03;
    public RectTransform _page04;
    public RectTransform _page05;
    public RectTransform _page06;

    // unitys start function
    void Start()
    {
        _titlePage.anchoredPosition = new Vector2(800f, _titlePage.anchoredPosition.y);
        _page01.anchoredPosition = new Vector2(1600f, _page01.anchoredPosition.y);
        _page02.anchoredPosition = new Vector2(2400f, _page02.anchoredPosition.y);
        _page03.anchoredPosition = new Vector2(3200f, _page03.anchoredPosition.y);
        _page04.anchoredPosition = new Vector2(4000f, _page04.anchoredPosition.y);
        _page05.anchoredPosition = new Vector2(4800f, _page05.anchoredPosition.y);
        _page06.anchoredPosition = new Vector2(5600f, _page06.anchoredPosition.y);

        GetComponent<UserTouchMovement>().enabled = false;
    }


}
