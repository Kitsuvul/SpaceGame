/*
Notes:

*/
using UnityEngine;

public class MaxDistanceScript : MonoBehaviour
{
    private GameObject rocketShipObj, soundObj;

    private void Awake()
    {
        rocketShipObj = GameObject.FindGameObjectWithTag("Player");
        soundObj = GameObject.FindGameObjectWithTag("SoundObject");
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("LOST");
        if (rocketShipObj != null && rocketShipObj.GetComponent<ShipControlsScript>().HasLaunched)
        {
            if (collision == rocketShipObj.GetComponent<Collider2D>())
            {
                soundObj.GetComponent<SoundHandler>().StopAudioRocketFlyingClip();
                rocketShipObj.GetComponent<BaseShipScript>().DestroyShip();
                rocketShipObj.GetComponent<ShipControlsScript>().OnDeathAnimation();
            }
        }
    }
}
