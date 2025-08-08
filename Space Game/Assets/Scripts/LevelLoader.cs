/*
Notes:
 - 

*/
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    #region Variables
    private GameObject winTriggerObj, rocketShipObj, settingsObj, cometObj;
    [SerializeField] private GameObject PlanetSmallPrefab;
    [SerializeField] private GameObject PlanetMediumPrefab;
    [SerializeField] private GameObject PlanetLargePrefab;
    private SaveManager saveManagerScript;
    private int currentLevel = 0;
    private bool levelLoaded = false;
    private GameObject[] loadedPlanetObjs;
    #endregion

    #region Properties
    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    public bool LevelLoaded
    {
        get { return levelLoaded; }
        private set { levelLoaded = value; }
    }
    #endregion

    #region Unity Functions
    private void Awake()
    {
        winTriggerObj = GameObject.FindGameObjectWithTag("WinBox");
        rocketShipObj = GameObject.FindGameObjectWithTag("Player");
        settingsObj = GameObject.FindGameObjectWithTag("PersistSettings");
        cometObj = GameObject.FindGameObjectWithTag("Comet");
        if (settingsObj != null)
        {
            saveManagerScript = settingsObj.GetComponent<SaveManager>();
            currentLevel = saveManagerScript.GetHighestLevelInPlayerPrefs();
        }
        winTriggerObj.transform.position = new Vector3(0.0f, 95.0f, 0.0f);
        loadedPlanetObjs = new GameObject[10];
    }

    public void Update()
    {
        if (!levelLoaded && PlanetSmallPrefab != null && PlanetMediumPrefab != null && PlanetLargePrefab != null)
        {
            LoadLevel(currentLevel);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Loads the level defined by the passed int
    /// </summary>
    /// <param name="x">The level to be loaded</param>
    private void LoadLevel(int x)
    {
        Debug.Log("Level:" + currentLevel);
        cometObj.GetComponent<CometHandler>().RandomizeCometDirectionAndSpeed();
        switch (x)
        {
            case 0:
                // --- Planets ---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 1:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 2:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(2.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(-2.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 3:
                //---Planets---
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(2.5f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(-5.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 4:
                //---Planets---
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(-2.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(2.5f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));


                levelLoaded = true;
                break;
            case 5:
                //---Planets---
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(-2.5f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(5.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));


                levelLoaded = true;
                break;
            case 6:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(-10.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(10.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 7:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(-10.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(10.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 8:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(-10.0f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(10.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 9:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(-5.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(5.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 10:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 35.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 11:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 12:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(2.5f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-2.5f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 13:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(6.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-2.5f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 14:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(-6.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(6.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 15:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(-6.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(6.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 16:
                // --- Planets ---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(-6.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(6.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 37.5f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 17:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(-6.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(6.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 37.5f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 18:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 37.5f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 19:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 37.5f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 20:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 21:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-5.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(5.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 22:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-2.5f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(10.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 23:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 24:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 20.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 25:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 35.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 20.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 26:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-5.0f, 35.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(5.0f, 35.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 27:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-5.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(5.0f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 28:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-5.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(5.0f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 29:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(10.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-10.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 70.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 30:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(10.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-10.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 35.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 31:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(5.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-5.0f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(-5.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(5.0f, 35.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 32:
                // --- Planets ---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(15.0f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-15.0f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 33:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(15.0f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-15.0f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(5.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(-5.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 34:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 75.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(5.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(-5.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 35:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 75.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 20.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 36:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 75.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(-15.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(15.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 37:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(10.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-10.0f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 38:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 75.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 39:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetSmallPrefab, new Vector3(7.5f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 40:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(7.5f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 41:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 42:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-2.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(2.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 43:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 35.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(7.5f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(7.05f, 55.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 44:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(10.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(5.0f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(-10.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 45:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-2.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(2.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 75.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(10.0f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(-10.0f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 46:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(2.5f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 40.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(10.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(10.0f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 47:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(0.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(-7.5f, 45.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 65.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(0.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 48:
                // --- Planets ---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-6.0f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-9.0f, 50.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(-5.0f, 20.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(9.0f, 70.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(5.0f, 80.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 49:
                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetMediumPrefab, new Vector3(-8.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-1.5f, 85.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[2] = Instantiate(PlanetMediumPrefab, new Vector3(7.5f, 30.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[3] = Instantiate(PlanetSmallPrefab, new Vector3(5.5f, 75.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[4] = Instantiate(PlanetSmallPrefab, new Vector3(-6.0f, 60.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
            case 50: // Large from here!
                //---Planets---

                levelLoaded = true;
                break;
            case 51:
                //---Planets---

                levelLoaded = true;
                break;
            case 52:
                //---Planets---

                levelLoaded = true;
                break;
            case 53:
                //---Planets---

                levelLoaded = true;
                break;
            case 54:
                //---Planets---

                levelLoaded = true;
                break;
            case 55:
                //---Planets---

                levelLoaded = true;
                break;
            case 56:
                //---Planets---

                levelLoaded = true;
                break;
            case 57:
                //---Planets---

                levelLoaded = true;
                break;
            case 58:
                //---Planets---

                levelLoaded = true;
                break;
            case 59:
                //---Planets---

                levelLoaded = true;
                break;
            case 60:
                //---Planets---

                levelLoaded = true;
                break;
            case 61:
                //---Planets---

                levelLoaded = true;

                break;
            case 62:
                //---Planets---

                levelLoaded = true;
                break;
            case 63:
                //---Planets---

                levelLoaded = true;
                break;
            case 64:
                // --- Planets ---

                levelLoaded = true;
                break;
            case 65:
                //---Planets---

                levelLoaded = true;
                break;
            case 66:
                //---Planets---

                levelLoaded = true;
                break;
            case 67:
                //---Planets---

                levelLoaded = true;
                break;
            case 68:
                //---Planets---

                levelLoaded = true;
                break;
            case 69:
                //---Planets---

                levelLoaded = true;
                break;
            case 70:
                //---Planets---

                levelLoaded = true;
                break;
            case 71:
                //---Planets---

                levelLoaded = true;
                break;
            case 72:
                //---Planets---

                levelLoaded = true;
                break;
            case 73:
                //---Planets---

                levelLoaded = true;
                break;
            case 74:
                //---Planets---

                levelLoaded = true;
                break;
            case 75:
                //---Planets---

                levelLoaded = true;

                break;
            case 76:
                //---Planets---

                levelLoaded = true;

                break;
            case 77:
                //---Planets---

                levelLoaded = true;

                break;
            case 78:
                //---Planets---

                levelLoaded = true;
                break;
            case 79:
                //---Planets---

                levelLoaded = true;
                break;
            case 80:
                // --- Planets ---

                levelLoaded = true;
                break;
            case 81:
                //---Planets---

                levelLoaded = true;
                break;
            case 82:
                //---Planets---

                levelLoaded = true;
                break;
            case 83:
                //---Planets---

                levelLoaded = true;
                break;
            case 84:
                //---Planets---

                levelLoaded = true;
                break;
            case 85:
                //---Planets---

                levelLoaded = true;
                break;
            case 86:
                //---Planets---

                levelLoaded = true;
                break;
            case 87:
                //---Planets---

                levelLoaded = true;
                break;
            case 88:
                //---Planets---

                levelLoaded = true;
                break;
            case 89:
                //---Planets---

                levelLoaded = true;
                break;
            case 90:
                //---Planets---

                levelLoaded = true;
                break;
            case 91:
                //---Planets---

                levelLoaded = true;

                break;
            case 92:
                //---Planets---

                levelLoaded = true;

                break;
            case 93:
                //---Planets---

                levelLoaded = true;

                break;
            case 94:
                //---Planets---

                levelLoaded = true;
                break;
            case 95:
                //---Planets---

                levelLoaded = true;
                break;
            case 96:
                //---Planets---

                levelLoaded = true;
                break;
            case 97:
                //---Planets---

                levelLoaded = true;

                break;
            case 98:
                //---Planets---

                levelLoaded = true;

                break;
            case 99:
                //---Planets---

                levelLoaded = true;

                break;
            default:
                Debug.Log("Loaded Default");

                //---Planets---
                loadedPlanetObjs[0] = Instantiate(PlanetSmallPrefab, new Vector3(10.0f, 75.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                loadedPlanetObjs[1] = Instantiate(PlanetMediumPrefab, new Vector3(-10.0f, 25.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

                levelLoaded = true;
                break;
        }
    }

    /// <summary>
    /// Loads the next level by incrementing the currentLevel and reseting bools
    /// </summary>
    public void LoadNextLevel()
    {
        rocketShipObj.GetComponent<ShipControlsScript>().ResetShipToStart();
        rocketShipObj.GetComponent<PreviousPathHandler>().ClearMarkers();
        DestroyPlanets();
        currentLevel++;
        if (settingsObj != null && currentLevel > saveManagerScript.GetHighestLevelInPlayerPrefs())
        {
            saveManagerScript.SetHighestLevelInPlayerPrefs(currentLevel);
        }
        levelLoaded = false;
    }

    /// <summary>
    /// Loads the next level by incrementing the currentLevel and reseting bools
    /// </summary>
    public void LoadSpecificLevel(int level)
    {
        rocketShipObj.GetComponent<ShipControlsScript>().ResetShipToStart();
        rocketShipObj.GetComponent<PreviousPathHandler>().ClearMarkers();
        DestroyPlanets();
        currentLevel = level;
        levelLoaded = false;
    }

    /// <summary>
    /// Reloads the current level
    /// </summary>
    public void ReloadLevel()
    {
        rocketShipObj.GetComponent<ShipControlsScript>().ResetShipToStart();
        DestroyPlanets();
        levelLoaded = false;
    }

    /// <summary>
    /// Destroys all the loaded planets, used for reseting or loading a new level
    /// </summary>
    private void DestroyPlanets()
    {
        if (loadedPlanetObjs.GetValue(0) != null)
        {
            foreach (GameObject planet in loadedPlanetObjs)
            {
                Destroy(planet);
            }
        }
    }
    #endregion
}