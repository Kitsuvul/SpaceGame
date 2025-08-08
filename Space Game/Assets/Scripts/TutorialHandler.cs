/*
Notes:

*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialTextFields, planetObj;
    [SerializeField] private GameObject ftlGateObj, rocketShipObj, cameraObj, exitDirectionArrowObj, boostBarObj, settingsObj;
    private Vector3[] cameraPositions = new Vector3[4];
    private Vector3 cameraStartPos = new Vector3( 0.0f, 47.5f, -10.0f );
    private bool playedAnimation = false;

    private int tutorialStage = 0;
    private LineRenderer lineRenderer;
    private int lineSteps = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraPositions[0] = new Vector3(0.0f, 10.0f, -10.0f);
        cameraPositions[1] = new Vector3(0.0f, 82.5f, -10.0f);
        cameraPositions[2] = new Vector3(0.0f, 58.0f, -10.0f);

        ftlGateObj.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            planetObj[i].SetActive(false);
        }

        settingsObj = GameObject.FindGameObjectWithTag("PersistSettings");

        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        rocketShipObj.GetComponent<ShipControlsScript>().canLaunch = false;
        cameraObj.transform.position = cameraStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        LoadTutorialStage(tutorialStage);

        if(tutorialStage == 5 && rocketShipObj.GetComponent<ShipControlsScript>().HasLaunched && rocketShipObj.GetComponent<ShipControlsScript>().RocketShipMagnitudeFromStart() > 10)
        {
            /// #### Pause Rocket here and move on to boost ####
            rocketShipObj.GetComponent<ShipControlsScript>().ResetShipToStart();
            LoadNextTutorialStage();
        }
    }

    void LoadTutorialStage(int stage)
    {
        switch (stage)
        {
            case 0:
                // Welcome to beyond apollo
                tutorialTextFields[0].SetActive(true);
                break;
            case 1:
                // Intro to the rocket
                tutorialTextFields[0].SetActive(false);
                tutorialTextFields[1].SetActive(true);

                // Adjust Camera
                cameraObj.transform.position = cameraPositions[0];
                cameraObj.GetComponent<Camera>().orthographicSize = 25f;

                // Draw Indicator
                DrawIndicator(rocketShipObj.transform.position + new Vector3(0.0f, 1.0f, 0.0f), 3);
                break;
            case 2:
                // Introduce Arrow
                tutorialTextFields[1].SetActive(false);
                tutorialTextFields[2].SetActive(true);

                // Draw Arrow
                exitDirectionArrowObj.GetComponent<ExitSignHandler>().tutorialActivated = true;

                // Draw Indicator
                DrawIndicator(exitDirectionArrowObj.transform.position, 2);
                break;
            case 3:
                // Introduce exit
                exitDirectionArrowObj.GetComponent<ExitSignHandler>().tutorialActivated = false;
                tutorialTextFields[2].SetActive(false);
                tutorialTextFields[3].SetActive(true);

                // Adjust Camera
                cameraObj.transform.position = cameraPositions[1];
                cameraObj.GetComponent<Camera>().orthographicSize = 25f;

                // Draw Indicator
                ftlGateObj.SetActive(true);
                DrawIndicator(ftlGateObj.transform.position, 4);
                break;
            case 4:
                // Introduce planets
                tutorialTextFields[3].SetActive(false);
                tutorialTextFields[4].SetActive(true);

                // Adjust Camera
                cameraObj.transform.position = cameraPositions[2];
                cameraObj.GetComponent<Camera>().orthographicSize = 45f;

                for (int i = 0; i < 3; i++)
                {
                    planetObj[i].SetActive(true);
                }
                break;
            case 5:
                // How to launch
                tutorialTextFields[4].SetActive(false);
                tutorialTextFields[5].SetActive(true);
                rocketShipObj.GetComponent<ShipControlsScript>().canLaunch = true;
                rocketShipObj.GetComponent<ShipControlsScript>().isTutorial = true;
                for (int i = 0; i < 3; i++)
                {
                    planetObj[i].SetActive(false);
                }

                // Adjust Camera
                if (!playedAnimation)
                {
                    cameraObj.transform.position = cameraStartPos;
                    cameraObj.GetComponent<Camera>().orthographicSize = 50f;
                    cameraObj.GetComponent<CameraScript>().PlayOnLevelLoadAnimation();
                    playedAnimation = true;
                }

                // Draw Indicator
                if (!rocketShipObj.GetComponent<ShipControlsScript>().IsTouched && !rocketShipObj.GetComponent<ShipControlsScript>().HasLaunched)
                {
                    DrawIndicator(rocketShipObj.transform.position, 3);
                }
                else
                {
                    tutorialTextFields[5].SetActive(false);
                    lineRenderer.enabled = false;
                }
                    break;
            case 6:
                // Boost
                rocketShipObj.GetComponent<ShipControlsScript>().isTutorial = false;
                tutorialTextFields[6].SetActive(true);
                boostBarObj.SetActive(true);
                break;
            default:

                break;
        }
    }

    public void LoadNextTutorialStage()
    {
        tutorialStage++;
    }

    public void ReturnToMainMenu()
    {
        settingsObj.GetComponent<SaveManager>().SetIsTutorialCompleteInPlayerPrefs(true);
        SceneManager.LoadScene(0);
    }

    void DrawIndicator(Vector3 objectPos, int scale)
    {
        lineRenderer.positionCount = lineSteps;

        for (int currentStep = 0; currentStep < lineSteps; currentStep++)
        {
            float circumfrerenceProg = (float)currentStep / lineSteps;
            float currentRaidan = circumfrerenceProg * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRaidan);
            float yScaled = Mathf.Sin(currentRaidan);

            float x = xScaled * scale;
            float y = yScaled * scale;

            Vector3 currentPosition = new Vector3(x, y, 0) + objectPos;
            lineRenderer.SetPosition(currentStep, currentPosition);
        }
    }
}
