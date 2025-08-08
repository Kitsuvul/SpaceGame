/*
Notes:

*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundHandler : MonoBehaviour
{
    private AudioSource audioSourceBackgroundMusic;
    private AudioSource audioSourceUIClip, audioSourceRocketLaunch, audioSourceRocketFlying;
    private SaveManager saveManager;
    [SerializeField] private AudioClip[] musicTracks;

    private float volume = 1;
    private float sfxVolume = 1;
    private bool isMuted = false;

    public float Volume
    {
        get { return volume; }
        set { volume = value; }
    }

    public float SFXVolume
    {
        get { return sfxVolume; }
        set { sfxVolume = value; }
    }

    public bool IsMuted
    {
        get { return isMuted; }
        set { isMuted = value; }
    }

    private static SoundHandler instance;

    private static SoundHandler Instance { get { return instance; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else { instance = this; }

        DontDestroyOnLoad(this.gameObject);

        audioSourceBackgroundMusic = this.gameObject.GetComponentAtIndex<AudioSource>(1);
        audioSourceUIClip = this.gameObject.GetComponentAtIndex<AudioSource>(2);
        audioSourceRocketLaunch = this.gameObject.GetComponentAtIndex<AudioSource>(3);
        audioSourceRocketFlying = this.gameObject.GetComponentAtIndex<AudioSource>(4);
        saveManager = GameObject.FindGameObjectWithTag("PersistSettings").GetComponent<SaveManager>();

        GetIsMutedFromPlayerPrefs();
        GetVolumeFromPlayerPrefs();
        GetSFXVolumeFromPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForChangesAudioSource();
        UpdateMusicTracks();
    }

    void UpdateMusicTracks()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 && audioSourceBackgroundMusic.clip != musicTracks[0])
        {
            Debug.Log("Next Track");
            audioSourceBackgroundMusic.clip = musicTracks[0];
            audioSourceBackgroundMusic.Play();
        }
        else if ((SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2) && audioSourceBackgroundMusic.clip != musicTracks[1])
        {
            Debug.Log("Next Track");
            audioSourceBackgroundMusic.clip = musicTracks[1];
            audioSourceBackgroundMusic.Play();
        }
    }

    public void PlayAudioButtonClickClip()
    {
        audioSourceUIClip.Play();
    }

    public void PlayAudioRocketLaunchClip()
    {
        audioSourceRocketLaunch.Play();
    }

    public void PlayAudioRocketFlyingClip()
    {
        StopAudioRocketLaunchClip();
        audioSourceRocketFlying.Play();
    }

    public void StopAudioRocketLaunchClip()
    {
        audioSourceRocketLaunch.Stop();
    }

    public void StopAudioRocketFlyingClip()
    {
        audioSourceRocketFlying.Stop();
    }

    private void GetIsMutedFromPlayerPrefs()
    {
        isMuted = saveManager.GetIsMutedInPlayerPrefs();
        audioSourceBackgroundMusic.mute = isMuted;
    }

    private void GetVolumeFromPlayerPrefs()
    {
        Volume = saveManager.GetVolumeInPlayerPrefs();
        audioSourceBackgroundMusic.volume = Volume;
    }

    private void GetSFXVolumeFromPlayerPrefs()
    {
        SFXVolume = saveManager.GetSFXVolumeInPlayerPrefs();
        audioSourceUIClip.volume = SFXVolume;
        audioSourceRocketLaunch.volume = SFXVolume;
        audioSourceRocketFlying.volume = SFXVolume;
    }

    void CheckForChangesAudioSource()
    {
        if(isMuted != audioSourceBackgroundMusic.mute)
        {
            audioSourceBackgroundMusic.mute = isMuted;
            audioSourceRocketLaunch.mute = isMuted;
            audioSourceRocketFlying.mute = isMuted;
            audioSourceUIClip.mute = isMuted;
            saveManager.SetIsMutedInPlayerPrefs(audioSourceBackgroundMusic.mute);
        }

        if (Volume != audioSourceBackgroundMusic.volume)
        {
            audioSourceBackgroundMusic.volume = Volume;
            saveManager.SetVolumeInPlayerPrefs(Volume);
        }

        if (SFXVolume != audioSourceUIClip.volume)
        {
            audioSourceRocketLaunch.volume = SFXVolume;
            audioSourceRocketFlying.volume = SFXVolume;
            audioSourceUIClip.volume = SFXVolume;
            saveManager.SetSFXVolumeInPlayerPrefs(SFXVolume);
        }
    }
}
