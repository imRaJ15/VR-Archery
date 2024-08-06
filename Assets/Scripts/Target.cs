using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameObject _pierchedArrowPrefab;
    private GameManager _gm;

    public GameObject Resorces { get; private set; }

    private void Start()
    {
        _pierchedArrowPrefab = Resources.Load<GameObject>("Prefab/PierchecArrow");
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hit") && !_gm.hasScore)
        {
            _gm.hasScore = true;
            StartCoroutine(TakeAnotherShotRoutine());

            _gm.ScoringSystem(gameObject.tag);

            if (_pierchedArrowPrefab != null)
            { Instantiate(_pierchedArrowPrefab, other.gameObject.transform.position, Quaternion.identity); }
            else { Debug.LogWarning("Prefab is Not Assigned"); }

            GameObject arrow = GameObject.Find("Arrow");
            if (arrow != null)
            { Destroy(arrow); }
            else { Debug.LogWarning("Arrow not found"); }
            Debug.Log(gameObject.tag);
        }
    }

    IEnumerator TakeAnotherShotRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        _gm.hasScore = false;
    }
}
