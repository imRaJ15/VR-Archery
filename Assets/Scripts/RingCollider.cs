using UnityEngine;

public class RingColliderSetup : MonoBehaviour
{
    public int numberOfColliders = 8;  // Number of colliders to form the ring
    public float radius = 5f;          // Radius of the ring
    public float colliderWidth = 1f;   // Width of each collider
    public float colliderThickness = 0.5f;
    public string areaName;

    void Start()
    {
        for (int i = 0; i < numberOfColliders; i++)
        {
            // Create a new GameObject for each collider
            GameObject box = new GameObject("BoxCollider" + i);
            box.tag = areaName;
            box.transform.parent = transform;
            box.AddComponent<Target>();
            box.AddComponent<BoxCollider>().isTrigger = true;

            // Calculate the angle and position for each collider
            float angle = i * Mathf.PI * 2f / numberOfColliders;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            box.transform.localPosition = pos;

            // Rotate the collider to face the center of the ring
            box.transform.localRotation = Quaternion.Euler(0, -angle * Mathf.Rad2Deg, 0);

            // Set the size of the BoxCollider
            box.GetComponent<BoxCollider>().size = new Vector3(colliderWidth, colliderThickness, radius * 2 * Mathf.PI / numberOfColliders);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hit"))
        {
            //Instantiate(_pierchedArrowPrefab, other.gameObject.transform.position, Quaternion.identity);
            //GameObject arrow = GameObject.Find("Arrow");
            //if (arrow != null) { Destroy(arrow); }
            Debug.Log(gameObject.tag);
        }
    }
}
