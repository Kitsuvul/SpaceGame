/*
Notes:

*/
using UnityEngine;

public class InputScript : MonoBehaviour
{

    /// <summary>
    /// Checks for a single click release from the User
    /// </summary>
    /// <returns>A bool based on whether there was a click released or not</returns>
    public bool CheckSingleClickUp()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Debug.Log("Mouse Button One Down");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks for a single down click from the User
    /// </summary>
    /// <returns>A bool based on whether there was a click down or not</returns>
    public bool CheckSingleClickDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("Mouse Button One Down");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks for a single touch from the User
    /// </summary>
    /// <returns>A bool based on whether there was a touch or not</returns>
    public bool CheckSingleTouch()
    {
        if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            //Debug.Log("Single Touch");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks for two touches from the User
    /// </summary>
    /// <returns>A bool based on whether there was two touches or not</returns>
    public bool CheckDoubleTouch()
    {
        if(Input.touchCount == 2)
        {
            //Debug.Log("Double Touch");
            return true;
        }
        return false;
    }

    bool CheckIfTouchOrClickReleased()
    {
        if(Input.GetTouch(0).phase == TouchPhase.Ended || CheckSingleClickUp())
        {
            return true;
        }

        return false;
    }

    public bool CheckIfMouseWheelIsMoving()
    {
        if (Input.mouseScrollDelta.x > 0 || Input.mouseScrollDelta.x < 0 || Input.mouseScrollDelta.y > 0 || Input.mouseScrollDelta.y < 0)
        {
            return true;
        }
        return false;
    }
}
