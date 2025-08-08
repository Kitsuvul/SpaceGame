/*
Notes:

*/
using UnityEngine;

public class EndlessLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region Old
        //rocketShip = GameObject.FindGameObjectWithTag("Player");


        //arrow = GameObject.FindGameObjectWithTag("Arrow");
        ////_line = arrow.GetComponent<LineRendererXD>();
        //_canvas = GameObject.FindGameObjectWithTag("CanvasUI");
        //_menuUI = _canvas.GetComponent<MenuAndUIScript>();


        //startPos = rocketShip.transform.position;
        //previousPos = new Vector3(0.0f, 0.0f, 0.0f);

        //frames = 0;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region Old
        // Try and make the planets consistantly spawn based on the player position
        // if statement for if their are less than the correct amount on the map
        // continue spawning the planets while the player is moving and change the spawn point 

        //frames++;

        //planet = GameObject.FindGameObjectsWithTag("Orbs");
        //amountPlanets = planet.Length;
        //currentPos = rocketShip.transform.position;

        //if (frames % 5 == 0)
        //{
        //    if (_menuUI.currentScene.buildIndex == 2 || _menuUI.currentScene.buildIndex == 3)
        //    {
        //        //if (currentPos != previousPos && _menuUI.cameraScript.isLaunched)
        //        //{
        //        //    Vector2 tempPos;
        //        //    planetSpawnPoint = findCentrePoint(currentPos, previousPos);

        //        //    tempPos = (new Vector2(planetSpawnPoint.x, planetSpawnPoint.y) + Random.insideUnitCircle * 200);
        //        //    if (checkSpawn(tempPos) == true)
        //        //    {
        //        //        SpawnPlanet(Random.Range(0, 3), tempPos, new Quaternion(0, 0, 0, 0));
        //        //    }

        //        //}
        //        destroyPlanets(false);
        //        previousPos = currentPos;
        //    }
        //}
        #endregion
    }

    #region Find Spawn Point

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cPos"></param>
    /// <param name="pPos"></param>
    /// <returns></returns>

    //public Vector2 findCentrePoint(Vector3 cPos, Vector3 pPos)
    //{
    //    Vector2 shipDirection = cPos - pPos;

    //    Vector2 finaldirection = shipDirection + (shipDirection.normalized * 350);

    //    Vector2 targetPos = new Vector2(pPos.x, pPos.y) + finaldirection;

    //    return targetPos;
    //}

    #endregion

    #region Spawn Planets

    /// <summary>
    /// Method that takes a planet type, spawn location and it's rotation
    /// </summary>
    /// <param name="_size"></param>
    /// <param name="_location"></param>
    /// <param name="rotation"></param>

    //public void SpawnPlanet(int _size, Vector3 _location, Quaternion rotation)
    //{
    //    switch (_size)
    //    {
    //        case 0:
    //            Instantiate(Resources.Load("Planet S"), _location, rotation);
    //            break;
    //        case 1:
    //            Instantiate(Resources.Load("Planet M"), _location, rotation);
    //            break;
    //        case 2:
    //            Instantiate(Resources.Load("Planet L"), _location, rotation);
    //            break;
    //        case 5:
    //            Instantiate(Resources.Load("DebugSpriteS"), _location, rotation);
    //            break;
    //        case 6:
    //            Instantiate(Resources.Load("DebugSpriteM"), _location, rotation);
    //            break;
    //        case 7:
    //            Instantiate(Resources.Load("DebugSpriteL"), _location, rotation);
    //            break;
    //        default:
    //            Instantiate(Resources.Load("PlanetS"), _location, rotation);
    //            break;
    //    }
    //}

    #endregion

    #region Check Spawn

    /// <summary>
    /// Checks the spawn location for planets so it can check if it's spawning correctly
    /// </summary>
    /// <returns></returns>
    /// 

    //public bool checkSpawn(Vector3 planetLoc)
    //{
    //    planet = GameObject.FindGameObjectsWithTag("Orbs");

    //    foreach (GameObject _planet in planet)
    //    {
    //        int magni = Mathf.RoundToInt(Vector3.Distance(planetLoc, _planet.transform.position));

    //        if (magni <= 7 && magni >= 0)
    //        {
    //            return false;
    //        }
    //    }

    //    return true;
    //}

    #endregion

    #region Load Endless

    //public void LoadLevel(float spawnLoc, bool fPlanet)
    //{
    //    int aOP = 175;


    //    if (fPlanet == true)
    //        SpawnPlanet(0, new Vector3(0, 13, 0), new Quaternion(0, 0, 0, 0));


    //    for (int x = 0; x < aOP; x++)
    //    {
    //        Vector3 vector3;
    //        do
    //        {
    //            vector3 = (new Vector2(0, spawnLoc) + Random.insideUnitCircle * 200);
    //        } while (checkSpawn(vector3) == false);

    //        SpawnPlanet(Random.Range(0, 3), vector3, new Quaternion(0, 0, 0, 0));
    //    }
    //}

    #endregion
}
