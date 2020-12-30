using UnityEngine;
using UnityEngine.UI;

public class GameCon : MonoBehaviour
{
    //Variables
    

    private void Update()
    {
        DragPages_Turning();
    }


    public void DragPages_Turning()
    {
        if(Input.GetMouseButton(0))
        {
            if (Screen.width > Screen.width / 2)
            {
                Debug.Log("Touch and drag right side of screen");
            }
        }
    }
}
