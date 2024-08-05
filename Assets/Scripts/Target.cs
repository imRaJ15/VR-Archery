using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] GameObject _pierchedArrowPrefab;

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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Hit"))
    //    {
    //        Instantiate(_pierchedArrowPrefab, collision.gameObject.transform.position, Quaternion.identity);
    //        GameObject arrow = GameObject.Find("Arrow");
    //        if (arrow != null) { Destroy(arrow); }
    //    }
    //}
}
