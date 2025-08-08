/*
Notes:

*/
using UnityEngine;

public class WinStateHandler : MonoBehaviour
{
    private GameObject rocketShipObj, soundObj;

    public void Awake()
    {
        rocketShipObj = GameObject.FindGameObjectWithTag("Player");
        soundObj = GameObject.FindGameObjectWithTag("SoundObject");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Won?");
        if(other.gameObject == rocketShipObj.gameObject)
        {
            ShipControlsScript shipControlsScript = rocketShipObj.GetComponent<ShipControlsScript>();
            soundObj.GetComponent<SoundHandler>().StopAudioRocketFlyingClip();
            shipControlsScript.RemoveVelocityFromShip();
            shipControlsScript.OnWinAnimation();
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
