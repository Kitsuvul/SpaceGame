/*
Notes:


*/
using UnityEngine;

public class CameraScript : MonoBehaviour {

    #region Private Variables
    private float OrthoZoomSpeed = 0.1f;
    private float cameraOrthoStartView = 16.875f;
    private bool hasAnimated = false;
    private bool hasAnimatedLevelIntro = false;
    private Vector3 cameraStartPos = new Vector3(0.0f, 47.5f, -10.0f);
    private Vector3 cameraStartPosPostAnim = new Vector3(0.0f, 15.5f, -10.0f);
    private GameObject rocketShipObj, gameControllerObj;
    private ShipControlsScript rocketControllerScript;
    private LevelLoader levelLoaderScript;
    private InputScript inputScript;
    private HelperScript helperScript;
    private Animation cameraAnim;

    // New Variables for behind Arrow
    private bool useNewArrowSystem = true;
    private Vector3 cameraStartPosPostAnimBehindArrow = new Vector3(0.0f, 10f, -10.0f);
    private float cameraOrthoStartViewBehindArrow = 20f;
    #endregion

    #region Properties
    public bool HasAnimated
    {
        get { return hasAnimated; }
        private set { hasAnimated = value; }
    }

    public bool HasAnimatedLevelIntro
    {
        get { return hasAnimatedLevelIntro; }
        private set { hasAnimatedLevelIntro = value; }
    }
    #endregion

    #region Unity Functions
    void Awake()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        inputScript = gameControllerObj.GetComponent<InputScript>();
        helperScript = gameControllerObj.GetComponent<HelperScript>();
        levelLoaderScript = gameControllerObj.GetComponent<LevelLoader>();


        rocketShipObj = GameObject.FindGameObjectWithTag("Player");
        rocketControllerScript = rocketShipObj.GetComponent<ShipControlsScript>();

        cameraAnim = this.GetComponent<Animation>();
    }

    void Update()
    {
        UpdateZoom();

        if (rocketControllerScript.HasLaunched && !hasAnimated)
        {
            UpdateCameraPositionOnLaunch();
        }

        if (levelLoaderScript && levelLoaderScript.LevelLoaded && !hasAnimatedLevelIntro)
        {
            PlayOnLevelLoadAnimation();
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Resets the camera to it's original starting point
    /// </summary>
    public void ResetCamera()
    {
        this.gameObject.transform.parent = null;
        this.gameObject.transform.position = cameraStartPos;
        this.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        hasAnimated = false;
        hasAnimatedLevelIntro = false;
    }

    /// <summary>
    /// Plays the intro camera animation on loading or reseting a level
    /// </summary>
    public void PlayOnLevelLoadAnimation()
    {
        if (!useNewArrowSystem)
        {
            cameraAnim["IntroShot"].wrapMode = WrapMode.Once;
            cameraAnim.Play("IntroShot");
            hasAnimatedLevelIntro = true;
            Debug.Log("Played");
        }
        else
        {
            cameraAnim["IntroShotBehindArrow"].wrapMode = WrapMode.Once;
            cameraAnim.Play("IntroShotBehindArrow");
            hasAnimatedLevelIntro = true;
            Debug.Log("Played");
        }

    }

    /// <summary>
    /// Plays a animation for the camera to rotate and lock with the rocket ship
    /// </summary>
    private void UpdateCameraPositionOnLaunch()
    {
        float magnitude = (helperScript.GetVec2FromPositionHelper(rocketShipObj.transform.position) - rocketControllerScript.StartPosition).magnitude;
        if (magnitude >= 5.5f && hasAnimated == false)
        {
            this.transform.parent = rocketShipObj.transform;
            this.transform.rotation = rocketShipObj.transform.rotation;
            this.transform.localPosition = new Vector3(10000.0f, 100000.0f, -14.6f);
            cameraAnim["CameraZoomOut"].wrapMode = WrapMode.Once;
            cameraAnim.Play("CameraZoomOut");
            hasAnimated = true;
        }
    }

    /// <summary>
    /// Standard update for handling the user inputed zoom controls
    /// </summary>
    private void UpdateZoom()
    {
        if (inputScript.CheckDoubleTouch())
        {
            // Gets the first two touches in the touch array
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Need to find the positions of the touches in the previous frame (A = CurrentPos - DeltaPos)
            Vector2 touchZeroPrevPos = touchZero.position /*Current Position of the touch*/ - touchZero.deltaPosition /*the difference in position between the touchs current position and position last frame*/;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; // Distance between points on the previous frame
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag; // The change in difference (Positive Results - Zoom Out, Negative Result - Zoom in)

            if (Camera.main.orthographic == true)
            {
                if(!useNewArrowSystem)
                {
                    Camera.main.orthographicSize += deltaMagnitudeDiff * OrthoZoomSpeed;
                    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 12.0f, 55.0f);
                    Camera.main.gameObject.transform.position = new Vector3(0.0f, Camera.main.orthographicSize - cameraOrthoStartView, 0.0f) + cameraStartPosPostAnim;
                }
                else
                {
                    Camera.main.orthographicSize += deltaMagnitudeDiff * OrthoZoomSpeed;
                    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 12.0f, 55.0f);
                    Camera.main.gameObject.transform.position = new Vector3(0.0f, Camera.main.orthographicSize - cameraOrthoStartViewBehindArrow, 0.0f) + cameraStartPosPostAnimBehindArrow;
                }
            }
        }
        else if (inputScript.CheckIfMouseWheelIsMoving())
        {
            if (Camera.main.orthographic == true)
            {
                if (!useNewArrowSystem)
                {
                    Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
                    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 12.0f, 55.0f);
                    Camera.main.gameObject.transform.position = new Vector3(0.0f, Camera.main.orthographicSize - cameraOrthoStartView, 0.0f) + cameraStartPosPostAnim;
                }
                else
                {
                    Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
                    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 12.0f, 55.0f);
                    Camera.main.gameObject.transform.position = new Vector3(0.0f, Camera.main.orthographicSize - cameraOrthoStartViewBehindArrow, 0.0f) + cameraStartPosPostAnimBehindArrow;
                }
            }
        }
    }
    #endregion
}
