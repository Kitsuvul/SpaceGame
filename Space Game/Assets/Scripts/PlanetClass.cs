/*
Notes:

*/
using UnityEngine;

public enum PlanetSizeEnum
{
    Small,
    Medium,
    Large
}

public class PlanetClass : MonoBehaviour
{
private
    PlanetSizeEnum planetSize;
    float gravityRadius;
    float gravityStrength;
    bool isInGravity = false;
    protected GameObject rocketShipObj;
    protected GameObject canvasObj;
    protected GameObject soundObj;
    private GameObject[] DebrisObjs;
    [SerializeField] private Sprite[] smallPlanetSprites;
    [SerializeField] private Sprite[] mediumPlanetSprites;
    [SerializeField] private Sprite[] largePlanetSprites;
    [SerializeField] private GameObject explosionObj;
    [SerializeField] private GameObject DebrisPrefab;
    private readonly Vector2[] debrisDirections = new Vector2[3];

    public PlanetSizeEnum PlanetSize
    {
        get { return planetSize; }
        private set { planetSize = value; }
    }
    public float GravityRadius
    {
        get { return gravityRadius; }
        private set { gravityRadius = value; }
    }
    public float GravityStrength
    {
        get { return gravityStrength; }
        private set { gravityStrength = value; }
    }
    public bool IsInGravity
    {
        get { return isInGravity; }
        set { isInGravity = value; }
    }

    void Awake()
    {
        rocketShipObj = GameObject.FindGameObjectWithTag("Player");
        canvasObj = GameObject.FindGameObjectWithTag("CanvasUI");
        soundObj = GameObject.FindGameObjectWithTag("SoundObject");

        if (this.name.Contains("Planet S"))
        {
            GravityRadius = 10.0f;
            GravityStrength = 2.5f;
            PlanetSize = PlanetSizeEnum.Small;
        }
        else if (this.name.Contains("Planet M"))
        {
            GravityRadius = 12.5f;
            GravityStrength = 3.0f;
            PlanetSize = PlanetSizeEnum.Medium;
        }
        else if (this.name.Contains("Planet L"))
        {
            GravityRadius = 15f;
            GravityStrength = 4.0f;
            PlanetSize = PlanetSizeEnum.Large;
            Debug.Log(largePlanetSprites.Length);
        }

        DebrisObjs = new GameObject[3];
        debrisDirections[0] = Vector2.left * 1000;
        debrisDirections[1] = Vector2.right * 1000;
        debrisDirections[2] = Vector2.down * 1000;
    }

    private void Start()
    {
        if (this.name.Contains("Planet S"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = smallPlanetSprites[1];
        }
        else if (this.name.Contains("Planet M"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = mediumPlanetSprites[1];
        }
        else if (this.name.Contains("Planet L"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = largePlanetSprites[1];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("DESTROY");
        if (collision == rocketShipObj.GetComponent<Collider2D>())
        {
            soundObj.GetComponent<SoundHandler>().StopAudioRocketFlyingClip();
            Instantiate(explosionObj, rocketShipObj.transform.position, rocketShipObj.transform.rotation);
            for (int i = 0; i < 3; ++i) 
            {
                DebrisObjs[i] = Instantiate(DebrisPrefab, rocketShipObj.transform.position, rocketShipObj.transform.rotation);
                DebrisObjs[i].GetComponent<DebrisHandler>().SetDirection(debrisDirections[i]);
            }
            
            rocketShipObj.GetComponent<BaseShipScript>().DestroyShip();
            rocketShipObj.GetComponent<ShipControlsScript>().OnDeathAnimation();
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject debris in DebrisObjs)
        {
            Destroy(debris);
        }
    }
}
