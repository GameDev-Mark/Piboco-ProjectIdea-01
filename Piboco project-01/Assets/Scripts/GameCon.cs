using UnityEngine;

public class GameCon : MonoBehaviour
{
    //Variables
    public GameObject pageMover;

    private void Update()
    {
        DragPages_Turning();
    }


    public void DragPages_Turning()
    {
        if(Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                pageMover.GetComponent<RectTransform>().Translate(Vector3.left * 3f);
                Debug.Log("Touch and drag right side of screen");
            }

            if (Input.mousePosition.x < Screen.width / 2)
            {
                pageMover.GetComponent<RectTransform>().Translate(Vector3.right * 3f);
                Debug.Log("Touch and drag left side of screen");
            }
            
        }
    }
}
