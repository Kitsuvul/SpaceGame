/*
Notes:

*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopLevelUIHandler : MonoBehaviour
{
    [SerializeField] protected GameObject levelPanelObj, inGamePanelObj, settingsPanelObj, winStatePanelObj, failStatePanelObj, loadingScreenPanelObj;

    protected GameObject rocketShipObj, gameControllerObj, mainCameraObj, exitArrowObj, exitGateObj, soundObj;
    protected LevelLoader levelLoader;
    protected CameraScript cameraScript;
    protected ExitSignHandler exitSignHandler;

    private bool uiIsOpen = false;

    public bool UIIsOpen
    {
        get { return uiIsOpen; }
        private set { uiIsOpen = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Getting Objects
        rocketShipObj = GameObject.FindGameObjectWithTag("Player");
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        exitArrowObj = GameObject.FindGameObjectWithTag("ExitSign");
        exitGateObj = GameObject.FindGameObjectWithTag("WinBox");
        soundObj = GameObject.FindGameObjectWithTag("SoundObject");

        levelLoader = gameControllerObj.GetComponent<LevelLoader>();
        cameraScript = mainCameraObj.GetComponent<CameraScript>();
        exitSignHandler = exitArrowObj.GetComponent<ExitSignHandler>();

        // On first load
        OpenLevelPanel();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfUIPanelsAreOpen();
    }

    #region Methods

    public void ResetToLoadNextLevel()
    {
        rocketShipObj.GetComponent<ShipControlsScript>().ResetShipToStart();
        rocketShipObj.GetComponent<PreviousPathHandler>().OnReset();
        cameraScript.ResetCamera();
        exitSignHandler.ResetExitArrow();
        levelLoader.LoadNextLevel();
        exitGateObj.GetComponent<Collider2D>().enabled = true;
    }

    public void ResetToLoadSpecificLevel(int level)
    {
        rocketShipObj.GetComponent<ShipControlsScript>().ResetShipToStart();
        rocketShipObj.GetComponent<PreviousPathHandler>().OnReset();
        cameraScript.ResetCamera();
        exitSignHandler.ResetExitArrow();
        levelLoader.LoadSpecificLevel(level);
    }

    public void ResetLevel()
    {
        if (rocketShipObj == null)
        {
            Instantiate(Resources.Load("SpaceShip"));
        }

        rocketShipObj.GetComponent<ShipControlsScript>().ResetShipToStart();
        soundObj.GetComponent<SoundHandler>().StopAudioRocketFlyingClip();
        rocketShipObj.GetComponent<PreviousPathHandler>().OnReset();
        levelLoader.ReloadLevel();
        cameraScript.ResetCamera();
        exitSignHandler.ResetExitArrow();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

    #region Open/Close Panel Methods

    public void OpenInGamePanel()
    {
        if (inGamePanelObj != null)
        {
            inGamePanelObj.SetActive(true);
            uiIsOpen = false;
        }
    }

    public void CloseInGamePanel()
    {
        if (inGamePanelObj != null)
        {
            inGamePanelObj.SetActive(false);
        }
    }

    public void OpenSettingsPanel()
    {
        if (settingsPanelObj != null)
        {
            settingsPanelObj.SetActive(true);
        }
    }

    public void CloseSettingsPanel()
    {
        if (settingsPanelObj != null)
        {
            settingsPanelObj.SetActive(false);
        }
    }

    public void OpenWinStatePanel()
    {
        if (winStatePanelObj != null)
        {
            winStatePanelObj.SetActive(true);
        }
    }

    public void CloseWinStatePanel()
    {
        if (winStatePanelObj != null)
        {
            winStatePanelObj.SetActive(false);
        }
    }

    public void OpenLevelPanel()
    {
        if (levelPanelObj != null)
        {
            levelPanelObj.SetActive(true);
            levelPanelObj.GetComponent<LevelUIPanelHandler>().loadedAllButtons = false;
        }
    }

    public void CloseLevelPanel()
    {
        if (levelPanelObj != null)
        {
            levelPanelObj.SetActive(false);
        }
    }

    public void OpenFailStatePanel()
    {
        if (failStatePanelObj != null)
        {
            failStatePanelObj.SetActive(true);
        }
    }

    public void CloseFailStatePanel()
    {
        if (failStatePanelObj != null)
        {
            failStatePanelObj.SetActive(false);
        }
    }

    private void CheckIfUIPanelsAreOpen()
    {
        if(failStatePanelObj.activeSelf == true || levelPanelObj.activeSelf == true || winStatePanelObj.activeSelf == true || settingsPanelObj.activeSelf == true)
        {
            uiIsOpen = true;
        }
        else
        {
            uiIsOpen = false;
        }
    }
    #endregion
}
