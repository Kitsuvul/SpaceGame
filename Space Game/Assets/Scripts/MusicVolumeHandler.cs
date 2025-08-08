/*
Notes:

*/
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeHandler : MonoBehaviour
{
    private GameObject soundObj;
    private Slider volumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        soundObj = GameObject.FindGameObjectWithTag("SoundObject");
        volumeSlider = this.gameObject.GetComponent<Slider>();

        if (soundObj != null && volumeSlider)
        {
            volumeSlider.value = soundObj.GetComponent<SoundHandler>().Volume;
            volumeSlider.onValueChanged.AddListener(delegate { OnValueChangeVolumeSlider(); });
        }
    }

    private void OnValueChangeVolumeSlider()
    {
        soundObj.GetComponent<SoundHandler>().Volume = volumeSlider.value;
    }
}
