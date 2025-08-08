/*
Notes:

*/
using UnityEngine;

public class ExitSignHandler : MonoBehaviour
{
    private GameObject winBoxObject, gameController, player;
    private HelperScript helperScript;

    public bool tutorialActivated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        winBoxObject = GameObject.FindGameObjectWithTag("WinBox");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
        helperScript = gameController.GetComponent<HelperScript>();
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<ShipControlsScript>().HasLaunched || tutorialActivated)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            UpdateExitArrow();
        }
    }
    private void UpdateExitArrow()
    {
        Quaternion rot = helperScript.CalculateRotationHelper(winBoxObject.transform.position, player.gameObject.transform.position);
        Matrix4x4 translatetoPivot = Matrix4x4.TRS(player.transform.position, Quaternion.identity, Vector3.one);
        Matrix4x4 m = Matrix4x4.Rotate(rot);
        Matrix4x4 translateBack = Matrix4x4.TRS(-player.transform.position, Quaternion.identity, Vector3.one);
        Matrix4x4 combined = translatetoPivot * m * translateBack;

        this.gameObject.transform.position = combined.MultiplyPoint3x4(new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 4.0f, player.gameObject.transform.position.z));
        this.gameObject.transform.rotation = helperScript.CalculateRotationHelper(winBoxObject.transform.position, player.gameObject.transform.position);
    }

    public void ResetExitArrow()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
