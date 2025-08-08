/*
Notes:

*/
using UnityEngine;

public class LineAndArrowHandler : MonoBehaviour
{
    #region Private Variables
    private LineRenderer launchLine;
    private ShipControlsScript controlsScript;
    private HelperScript helperScript;
    private GameObject player, gameController;

    private bool isPCControls = false;
    private bool hasBeenSetup = false;

    // New Arrow System
    private bool useNewArrowSystem = true;
    #endregion

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        helperScript = gameController.GetComponent<HelperScript>();
        launchLine = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleLineDrawing();
    }

    public void SetUpLine(bool isPC, ShipControlsScript shipControlsScript)
    {
        controlsScript = shipControlsScript;
        isPCControls = isPC;

        launchLine.enabled = true;
        if(!useNewArrowSystem)
        {
            launchLine.positionCount = 2;
            launchLine.SetPosition(0, player.transform.position);
            launchLine.SetPosition(1, this.gameObject.transform.position);
        }
        else
        {
            launchLine.positionCount = 3;
            launchLine.SetPosition(0, player.transform.position);
            launchLine.SetPosition(1, this.gameObject.transform.position);
        }

        hasBeenSetup = true;
    }

    private void HandleLineDrawing()
    {
        if (hasBeenSetup)
        {
            if(!useNewArrowSystem)
            {
                if (isPCControls)
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    this.gameObject.transform.position = new Vector2(Mathf.Clamp(mousePos.x, -8f, 8f), Mathf.Clamp(mousePos.y, 0.0f, 8.0f));
                }
                else
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    this.gameObject.transform.position = new Vector2(Mathf.Clamp(touchPos.x, -8f, 8f), Mathf.Clamp(touchPos.y, 0.0f, 8.0f));
                }

                launchLine.SetPosition(1, this.gameObject.transform.position);
                this.gameObject.transform.rotation = helperScript.CalculateRotationHelper(this.gameObject.transform.position, player.transform.position);
            }
            else
            {
                if (isPCControls)
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    this.gameObject.transform.position = helperScript.GetReverseVector2(new Vector2(Mathf.Clamp(mousePos.x, -8f, 8f), Mathf.Clamp(mousePos.y, -8.0f, 0.0f)));
                    launchLine.SetPosition(0, mousePos);
                    launchLine.SetPosition(1, player.transform.position);
                    launchLine.SetPosition(2, this.gameObject.transform.position);
                }
                else
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    this.gameObject.transform.position = helperScript.GetReverseVector2(new Vector2(Mathf.Clamp(touchPos.x, -8f, 8f), Mathf.Clamp(touchPos.y, -8.0f, 0.0f)));
                    launchLine.SetPosition(1, this.gameObject.transform.position);
                    launchLine.SetPosition(2, touchPos);
                }


                this.gameObject.transform.rotation = helperScript.CalculateRotationHelper(this.gameObject.transform.position, player.transform.position);
            }


            if (controlsScript)
            {
                if (controlsScript.HasLaunched == true)
                {
                    launchLine.enabled = false;
                    Destroy(this.gameObject);
                    Debug.Log("Destroyed");
                }
            }
            else
            {
                Debug.LogWarning("Can't find the controlsScript");
            }
        }
    }
}
