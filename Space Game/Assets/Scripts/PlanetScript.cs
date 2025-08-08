/*
Notes:

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : PlanetClass {

    #region Private Variables
    private Vector3 rotationVec = new Vector3(0.0f, 0.0f, 10.0f);
    private LineRenderer lineRenderer;
    private int lineSteps = 50;
    #endregion

    private void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();

        DrawGravityIndicator();
    }

    private void Update()
    {
        RotatePlanet();
    }

    private void FixedUpdate()
    {
        #region Gravity For Story
        if(!rocketShipObj.GetComponent<BaseShipScript>().IsDead)
        {
            HandleGravity();
        }

        #endregion

        #region Gravity for Endless
        //else if (UIScript.currentScene.buildIndex == 2 || UIScript.currentScene.buildIndex == 3)
        //{
        //    HandleEndlessGravity();
        //}
        #endregion
    }
    private void HandleGravity()
    {
        PlanetGravity(this.GravityRadius, this.GravityStrength);
    }

    /// <summary>
    /// Makes the planet rotate around its z axis
    /// </summary>
    private void RotatePlanet()
    {
        this.transform.Rotate(rotationVec * Time.deltaTime);
    }

    void PlanetGravity(float gravitySize, float gravityForce)
    {
        Vector3 rocketPos = rocketShipObj.transform.position;
        Vector3 planetPos = this.transform.position;

        float rocketPlanetMag = (planetPos - rocketPos).magnitude;
        if (rocketPlanetMag < gravitySize)
        {
            rocketShipObj.GetComponent<Rigidbody2D>().AddForce((planetPos - rocketPos) * gravityForce);
            IsInGravity = true;
            Debug.Log("IS IN GRAVITY");
        }
        else { IsInGravity = false; }
    }

    void DrawGravityIndicator()
    {
        lineRenderer.positionCount = lineSteps;

        for (int currentStep = 0; currentStep < lineSteps; currentStep++)
        {
            float circumfrerenceProg = (float)currentStep / lineSteps;
            float currentRaidan = circumfrerenceProg * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRaidan);
            float yScaled = Mathf.Sin(currentRaidan);

            float x = xScaled * GravityRadius;
            float y = yScaled * GravityRadius;

            Vector3 currentPosition = new Vector3(x, y, 0) + this.gameObject.transform.position;
            lineRenderer.SetPosition(currentStep, currentPosition);
        }
    }

    //private void HandleEndlessGravity()
    //{
    //    Vector3 rocketPos = rocketShip.transform.position;
    //    Vector3 planetPos = this.transform.position;

    //    float rocketPlanetMag = (planetPos - rocketPos).magnitude;

    //    if (rocketPlanetMag < 5 && UIScript.hasDied != true)
    //    {
    //        rocketShip.GetComponent<Rigidbody2D>().AddForce((planetPos - rocketPos) * 1.75f);
    //        IsInGrav = true;
    //        //if (UIScript.cameraScript.boost < 1000)
    //        //{
    //        //    UIScript.cameraScript.boost++;
    //        //}
    //        //UIScript.cameraScript.boost++;
    //        Debug.Log("Adding Force");
    //    }
    //    else { IsInGrav = false; }
    //}
}
