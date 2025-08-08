/*
Notes:

*/
using UnityEngine;
using UnityEngine.UI;

public class LevelUIPanelHandler : MonoBehaviour
{
    [SerializeField] public GameObject[] levelButtons;
    [SerializeField] public GameObject closeMenuButton;
    [SerializeField] public GameObject firstTimeTutorialText;
    private GameObject gameControllerObj;
    private GameObject settingsObj;
    public bool loadedAllButtons = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(closeMenuButton != null)
        {
            closeMenuButton.SetActive(false);
        }
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        foreach (GameObject button in levelButtons)
        {
            button.SetActive(false);
        }

        settingsObj = GameObject.FindGameObjectWithTag("PersistSettings");
        if (settingsObj && firstTimeTutorialText != null)
        {
            if (settingsObj.GetComponent<SaveManager>().GetHighestLevelInPlayerPrefs() == 0)
            {
                firstTimeTutorialText.GetComponent<Text>().text = "Click the first Red Button to start a level!";
            }
            else
            {
                firstTimeTutorialText.GetComponent<Text>().text = "Levels";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // currentlevel has changed 

        if (this.gameObject.activeSelf == true && !loadedAllButtons && gameControllerObj != null)
        {
            for (int i = 0; i <= gameControllerObj.GetComponent<LevelLoader>().CurrentLevel; i++)
            {
                levelButtons[i].SetActive(true);
            }

            loadedAllButtons = true;
        }
    }

    public void EnableCloseMenuButton()
    {
        closeMenuButton.SetActive(true);
    }
}
