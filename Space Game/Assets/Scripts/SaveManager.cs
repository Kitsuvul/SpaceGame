using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;

    private static SaveManager Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else { instance = this; }

        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolumeInPlayerPrefs(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetVolumeInPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            return PlayerPrefs.GetFloat("Volume");
        }
        else { return 0.1f; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="volume"></param>
    public void SetSFXVolumeInPlayerPrefs(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public float GetSFXVolumeInPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            return PlayerPrefs.GetFloat("SFXVolume");
        }
        else { return 0.1f; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isMuted"></param>
    public void SetIsMutedInPlayerPrefs(bool isMuted)
    {
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool GetIsMutedInPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("IsMuted"))
        {
            return PlayerPrefs.GetInt("IsMuted") != 0;
        }
        else { return false; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isMuted"></param>
    public void SetIsTutorialCompleteInPlayerPrefs(bool hasCompleted)
    {
        PlayerPrefs.SetInt("TutorialComplete", hasCompleted ? 1 : 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool GetIsTutorialCompleteInPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("TutorialComplete"))
        {
            return PlayerPrefs.GetInt("TutorialComplete") != 0;
        }
        else { return false; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="level"></param>
    public void SetHighestLevelInPlayerPrefs(int level)
    {
        PlayerPrefs.SetInt("Level", level);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetHighestLevelInPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            return PlayerPrefs.GetInt("Level");
        }
        else { return 0; }
    }
}