/*
Notes:
 - 

*/
using UnityEngine;

public class BaseShipScript : MonoBehaviour
{
    #region Variables
    private GameObject gameControllerObj, arrowObj, mainCamera, canvasObj;
    private TopLevelUIHandler topLevelUIScript;
    private ShipControlsScript shipControlsScript;
    private HelperScript helperScript;
    private bool isDead = false;
    #endregion

    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    #region Unity Functions
    void Awake()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        helperScript = gameControllerObj.GetComponent<HelperScript>();
        shipControlsScript = this.gameObject.GetComponent<ShipControlsScript>();
        canvasObj = GameObject.FindGameObjectWithTag("CanvasUI");
        topLevelUIScript = canvasObj.GetComponent<TopLevelUIHandler>();
        mainCamera = Camera.main.gameObject;
    }

    void Update()
    {
        RotateShipToFaceDirection();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Functions for when the rocket ship collides with a planet or solid object, resets the camera and velocity
    /// </summary>
    public void DestroyShip()
    {
        if(mainCamera && shipControlsScript)
        {
            mainCamera.transform.parent = null;
            shipControlsScript.RemoveVelocityFromShip();
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            isDead = true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void PostWinAnimation()
    {
        if (topLevelUIScript != null)
        {
            topLevelUIScript.OpenWinStatePanel();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void PostDeathAnimation()
    {
        if (topLevelUIScript != null)
        {
            topLevelUIScript.OpenFailStatePanel();
        }
    }

    /// <summary>
    /// Makes the SpaceShip face the direction of travel
    /// </summary>
    public void RotateShipToFaceDirection()
    {
        if (shipControlsScript != null && shipControlsScript.HasLaunched)
        {
            Vector2 currDir = this.gameObject.GetComponent<Rigidbody2D>().linearVelocity;

            if (currDir != Vector2.zero)
            {
                float angle = (Mathf.Atan2(currDir.y, currDir.x) * Mathf.Rad2Deg) - 90.0f;
                this.gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else if (shipControlsScript != null && !shipControlsScript.HasLaunched && shipControlsScript.IsTouched && arrowObj)
        {
            if (arrowObj == null)
            {
                arrowObj = GameObject.FindGameObjectWithTag("Arrow");
            }
            this.gameObject.transform.rotation = helperScript.CalculateRotationHelper(arrowObj.transform.position, this.gameObject.transform.position); ;
        }
    }
    #endregion
}
