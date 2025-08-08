using UnityEngine;

public class DebrisHandler : MonoBehaviour
{
    private Vector3 rotationVec = new Vector3(0.0f, 0.0f, 10.0f);
    private Vector2 directionVector = Vector2.zero;
    private bool appliedForce = false;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateDebris(Random.Range(10,15));

        if(!appliedForce && directionVector != Vector2.zero)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(directionVector);
            appliedForce = true;
        }
    }

    private void RotateDebris(int randomSpeed)
    {
        this.transform.Rotate(rotationVec * (Time.deltaTime * randomSpeed));
    }

    public void SetDirection(Vector2 direction)
    {
        directionVector = direction;
    }
}
