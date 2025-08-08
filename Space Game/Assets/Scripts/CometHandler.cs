/*
Notes:

*/
using UnityEngine;

public class CometHandler : MonoBehaviour
{
    private Vector2 orbitCentrePoint;
    private Vector3 orbitDirection;
    private LevelLoader levelLoader;
    private Vector2 cometStartPoint;
    private TrailRenderer trailRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        levelLoader = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelLoader>();
        orbitCentrePoint = new Vector2(0f, -71.0f);
        trailRenderer = this.gameObject.GetComponent<TrailRenderer>();
        RandomizeCometDirectionAndSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelLoader != null && levelLoader.LevelLoaded)
        {
            transform.RotateAround(orbitCentrePoint, orbitDirection, 50 * Time.deltaTime);

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void RandomizeCometDirectionAndSpeed()
    {
        int randomNumber = Random.Range(0, 9);
        if (randomNumber < 5)
        {
            orbitDirection = Vector3.forward;
        }
        else
        {
            orbitDirection = -Vector3.forward;
        }

        cometStartPoint = new Vector2(Random.Range(100f, 141f), -71f);
        trailRenderer.time = 0;
        this.gameObject.transform.position = cometStartPoint;
        trailRenderer.time = 0.15f;
    }
}
