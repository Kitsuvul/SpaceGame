/*
Notes:

*/
using UnityEngine;
using UnityEngine.UI;

public class MuteVolumeHandler : MonoBehaviour
{
    private GameObject soundObj;
    private Toggle muteAllToggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        soundObj = GameObject.FindGameObjectWithTag("SoundObject");
        muteAllToggle = this.gameObject.GetComponent<Toggle>();

        if (soundObj != null && muteAllToggle)
        {
            muteAllToggle.isOn = soundObj.GetComponent<SoundHandler>().IsMuted;
            muteAllToggle.onValueChanged.AddListener(delegate { OnValueMuteAllToggle(); });
        }
    }

    private void OnValueMuteAllToggle()
    {
        soundObj.GetComponent<SoundHandler>().IsMuted = muteAllToggle.isOn;
    }
}
