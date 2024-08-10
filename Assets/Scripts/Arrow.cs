using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody arrowRB;

    // Start is called before the first frame update
    void Start()
    {
        arrowRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowRB.AddForce(transform.forward * -0.04f, ForceMode.Impulse);
        DestroyArrow();
    }

    private void DestroyArrow()
    {
        if (OutOfBoundary())
        {
            Destroy(this.gameObject);
        }
    }

    private bool OutOfBoundary()
    {
        if (transform.position.x > 4.0f || transform.position.x < -12.5f ||
            transform.position.y > 8.0f || transform.position.y < -8.0f ||
            transform.position.z > 17.25f || transform.position.z < -10.0f)
        { return true; }
        else
        { return false; }   
    }
}
