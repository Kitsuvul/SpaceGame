/*
Notes:

*/
using System.Collections.Generic;
using UnityEngine;

public class PreviousPathHandler : MonoBehaviour
{
    #region Variables
    private List<Vector2> pathPoints;
    private List<GameObject> spawnedMarkers;
    private List<GameObject> previousRunMarkers;
    private ShipControlsScript controlsScript;
    private GameObject rocketShipObj, markerContainer;

    [SerializeField] private GameObject markerObj;
    [SerializeField] private float interval = 3.0f;
    #endregion

    #region Unity Functions
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pathPoints = new List<Vector2>();
        spawnedMarkers = new List<GameObject>();
        previousRunMarkers = new List<GameObject>();
        rocketShipObj = this.gameObject;
        controlsScript = rocketShipObj.GetComponent<ShipControlsScript>();
        markerContainer = GameObject.FindGameObjectWithTag("MarkerContainer");
        pathPoints.Add(controlsScript.StartPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsScript.HasLaunched) // Add a pause for when you die
        {
            SpawnMarkers();

        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Instantiates a marker along the part traveled route
    /// </summary>
    private void SpawnMarkers()
    {
        if (CheckDistanceFromLastMarker())
        {
            spawnedMarkers.Add(Instantiate(markerObj, this.gameObject.transform.position, this.gameObject.transform.rotation));
            spawnedMarkers[spawnedMarkers.Count - 1].gameObject.transform.parent = markerContainer.transform;
            pathPoints.Add(this.gameObject.transform.position);
        }
    }

    /// <summary>
    /// Clears the previous markers and moves the current markers to the previous markers list
    /// </summary>
    public void OnReset()
    {
        foreach (GameObject marker in previousRunMarkers)
        {
            Destroy(marker);
        }
        previousRunMarkers.Clear();
        foreach (GameObject marker in spawnedMarkers)
        {
            previousRunMarkers.Add(marker);
        }
        spawnedMarkers.Clear();
        pathPoints.Clear();
        pathPoints.Add(controlsScript.StartPosition);
    }

    /// <summary>
    /// Clears all markers
    /// </summary>
    public void ClearMarkers() 
    {
        foreach (GameObject marker in spawnedMarkers) 
        {
            Destroy(marker);
        }

        foreach (GameObject marker in previousRunMarkers)
        {
            Destroy(marker);
        }

        spawnedMarkers.Clear();
        previousRunMarkers.Clear();
        pathPoints.Add(controlsScript.StartPosition);
    }

    /// <summary>
    /// Checks if the rocket ship has traveled the required distance to Instantiate a new marker
    /// </summary>
    /// <returns></returns>
    bool CheckDistanceFromLastMarker()
    {
        Vector2 currPosition = this.gameObject.transform.position;
        Vector2 prevPoint = pathPoints[pathPoints.Count - 1];
        float magnitude = (currPosition - prevPoint).magnitude;

        if (magnitude > interval)
        {
            return true;
        }

        return false;
    }
    #endregion
}
