/*
Notes:

*/
using UnityEngine;

public class ShipControlsScript : MonoBehaviour
{
    #region Private Variables
    private const int boostPower = 10;
    private int maxPower = 1500, boost = 1000;
    private bool hasLaunched = false;
    private bool isTouched = false;
    private bool isBoosting = false;
    private bool boostEnable = false;
    private Vector2 startPos = new Vector2(0.0f, 0.0f);
    private Vector3 launchDir = new Vector3(0.0f, 10.0f, 0.0f);
    private GameObject rocketShip, gameController, arrowObject, soundObj, uiHandlerObj;
    private InputScript inputHelperScript;
    private HelperScript baseHelperScript;
    private Animator rocketAnimator;

    [SerializeField] 
    private GameObject arrowPrefab;

    public bool canLaunch = true;
    public bool isTutorial = false;
    #endregion

    #region Properties
    public bool HasLaunched
    {
        get { return hasLaunched; }
        private set { hasLaunched = value; }
    }

    public bool IsTouched
    {
        get { return isTouched; }
        private set { isTouched = value; }
    }

    public int Boost
    {
        get { return boost; }
        private set { boost = value; }
    }

    public Vector2 StartPosition
    {
        get { return startPos; }
        private set { startPos = value; }
    }
    #endregion

    #region Unity Methods
    void Awake()
    {
        rocketShip = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        soundObj = GameObject.FindGameObjectWithTag("SoundObject");
        uiHandlerObj = GameObject.FindGameObjectWithTag("CanvasUI");
        inputHelperScript = gameController.GetComponent<InputScript>();
        baseHelperScript = gameController.GetComponent<HelperScript>();
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        rocketAnimator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rocketAnimator.SetBool("HasLaunched", hasLaunched);
        rocketAnimator.SetBool("IsBoosting", isBoosting);

        if (inputHelperScript != null)
        {
            if (hasLaunched)
            {
                UpdateBoostControls();
            }
            else
            {
                UpdateLaunchControls();
            }
        }
        else
        {
            Debug.LogWarning("Unable to find input script!");
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// 
    /// </summary>
    void UpdateBoostControls()
    {
        if(!boostEnable)
        {
            float rocketPlanetMag = (baseHelperScript.GetVec2FromPositionHelper(this.gameObject.transform.position) - startPos).magnitude;
            if(rocketPlanetMag > 10.0)
            {
                boostEnable = true;
            }
        }

        if (boostEnable)
        {
            if (boost > 0)
            {
                if (inputHelperScript.CheckSingleClickDown() && !isBoosting)
                {
                    AddOrRemoveForceOnRocket(boostPower);
                }
                else if (inputHelperScript.CheckSingleClickUp() && isBoosting)
                {
                    AddOrRemoveForceOnRocket(-boostPower);
                }
                else if (inputHelperScript.CheckSingleTouch())
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began && !isBoosting)
                    {
                        AddOrRemoveForceOnRocket(boostPower);
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Ended && isBoosting)
                    {
                        AddOrRemoveForceOnRocket(-boostPower);
                    }
                }
            }

            if (boost <= 0 && isBoosting)
            {
                AddOrRemoveForceOnRocket(-boostPower);
            }

            if (isBoosting)
            {
                boost--;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void UpdateLaunchControls()
    {
        if (!isTouched)
        {
            // Checking if the player has touched the rocket
            if (inputHelperScript.CheckSingleTouch())
            {
                CheckRocketForTouch(Input.GetTouch(0).position, false);

            }
            else if (inputHelperScript.CheckSingleClickDown())
            {
                CheckRocketForTouch(baseHelperScript.GetVec2FromPositionHelper(Input.mousePosition), true);
            }
        }
        else if (isTouched)
        {
            // Launching the Rocket
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                LaunchRocketShip(Input.GetTouch(0).position);
            }
            else if(inputHelperScript.CheckSingleClickUp())
            {
                LaunchRocketShip(baseHelperScript.GetVec2FromPositionHelper(Input.mousePosition));
            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputPosition"></param>
    /// <param name="isPCControls"></param>
    private void CheckRocketForTouch(Vector2 inputPosition, bool isPCControls = false)
    {
        Vector2 raycast = Camera.main.ScreenToWorldPoint(inputPosition);
        RaycastHit2D rayCastHit = Physics2D.Raycast(raycast, inputPosition);
        if (rayCastHit.collider && uiHandlerObj != null)
        {
            LogColliderHitAndDrawArrow(rayCastHit, inputPosition, isPCControls);
        }
        else if (rayCastHit.collider && isTutorial)
        {
            LogColliderHitAndDrawArrow(rayCastHit, inputPosition, isPCControls);
        }
    }

    private void LogColliderHitAndDrawArrow(RaycastHit2D rayCastHit, Vector2 inputPosition, bool isPCControls)
    {
        Debug.Log("Hit Something: " + rayCastHit.collider.gameObject.name);
        if (rayCastHit.collider.gameObject == this.gameObject)
        {
            Debug.Log("Hit Player");
            DrawDirectionalArrow(inputPosition, startPos, isPCControls);
            isTouched = true;
        }
        else { isTouched = false; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputPosition"></param>
    /// <param name="playerPosition"></param>
    /// <param name="isPcControls"></param>
    private void DrawDirectionalArrow(Vector3 inputPosition, Vector3 playerPosition, bool isPcControls)
    {
        Vector3 arrowPos = Camera.main.ScreenToWorldPoint(inputPosition);
        arrowPos.z = 1;
        Vector3 arrowDir = arrowPos - playerPosition;
        Debug.Log("Draw Arrow");
        arrowObject = Instantiate(arrowPrefab, arrowPos, Quaternion.Euler(arrowDir));
        arrowObject.GetComponent<LineAndArrowHandler>().SetUpLine(isPcControls, this);
    }

    /// <summary>
    /// 
    /// </summary>
    public void AddForceToRocket()
    {
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        rocketShip.GetComponent<Rigidbody2D>().AddForce(launchDir.normalized * maxPower);
        soundObj.GetComponent<SoundHandler>().PlayAudioRocketFlyingClip();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputPosition"></param>
    private void LaunchRocketShip(Vector2 inputPosition)
    {
        if (inputPosition.y >= -2 && canLaunch)
        {
            launchDir = arrowObject.transform.position - rocketShip.transform.position;
            soundObj.GetComponent<SoundHandler>().PlayAudioRocketLaunchClip();
            hasLaunched = true;
        }
        isTouched = false;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="power"></param>
    private void AddOrRemoveForceOnRocket(int power)
    {
        rocketShip.GetComponent<Rigidbody2D>().AddForce(rocketShip.GetComponent<Rigidbody2D>().linearVelocity.normalized * power, ForceMode2D.Impulse);
        isBoosting = !isBoosting;
    }


    /// <summary>
    /// Resets the ship to the start position
    /// </summary>
    public void ResetShipToStart()
    {
        if(this.gameObject)
        {
            this.gameObject.transform.position = startPos;
            this.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            RemoveVelocityFromShip();

            hasLaunched = false;
            isTouched = false;
            isBoosting = false;
            boostEnable = false;
            this.gameObject.GetComponent<BaseShipScript>().IsDead = false;
            boost = 1000;

            rocketAnimator.SetTrigger("OnReset");
            if(this.gameObject.GetComponent<SpriteRenderer>().enabled == false)
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;

            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnWinAnimation()
    {
        rocketAnimator.SetTrigger("OnWin");
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnDeathAnimation()
    {
        rocketAnimator.SetTrigger("OnDeath");
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnLostAnimation()
    {
        rocketAnimator.SetTrigger("OnLost");
    }

    /// <summary>
    /// 
    /// </summary>
    public void RemoveVelocityFromShip()
    {
        Rigidbody2D rocketBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        if (rocketBody2D.bodyType != RigidbodyType2D.Static)
        {
            rocketBody2D.totalForce = Vector2.zero;
            rocketBody2D.linearVelocity = Vector2.zero;
            rocketBody2D.angularVelocity = 0.0f;
        }
    }

    public float RocketShipMagnitudeFromStart()
    {
        return (baseHelperScript.GetVec2FromPositionHelper(this.gameObject.transform.position) - startPos).magnitude;
    }
    #endregion
}
