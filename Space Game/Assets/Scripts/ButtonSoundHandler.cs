/*
Notes:

*/
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundHandler : MonoBehaviour
{
    private GameObject soundHandlerObj;
    private Button buttonObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundHandlerObj = GameObject.FindGameObjectWithTag("SoundObject");
        buttonObj = this.gameObject.GetComponent<Button>();
        buttonObj.onClick.AddListener(PlayAudioOnClick);
    }

    void PlayAudioOnClick()
    {
        soundHandlerObj.GetComponent<SoundHandler>().PlayAudioButtonClickClip();
    }
}
