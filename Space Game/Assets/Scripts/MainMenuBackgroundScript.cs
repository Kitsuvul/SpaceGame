/*
Notes:

*/
using UnityEngine;

public class MainMenuBackgroundScript : MonoBehaviour
{
    private Vector3 rotationVec = new Vector3(0.0f, 0.0f, 10.0f);

    // Update is called once per frame
    void Update()
    {
        RotateBackGround();
    }

    private void RotateBackGround()
    {
        if (this.gameObject.activeSelf)
        {
            this.transform.Rotate(rotationVec * Time.deltaTime);
        }
    }
}
