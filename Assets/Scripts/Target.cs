using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    private AudioSource[] audioSource;
    private GameObject _pierchedArrowPrefab;
    private GameManager _gm;

    public GameObject Resorces { get; private set; }

    private void Start()
    {
        _pierchedArrowPrefab = Resources.Load<GameObject>("Prefab/PierchecArrow");
        if (_pierchedArrowPrefab == null )
        { Debug.LogWarning("Arrow Prefab not Found"); }

        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if ( _gm == null )
        { Debug.LogWarning("GameManager not found"); }

        audioSource = new AudioSource[2];
        audioSource[0] = GameObject.Find("LeftAudioSource").GetComponent<AudioSource>();
        if (audioSource[0] == null )
        { Debug.Log("Left Side Audio not found"); }

        audioSource[1] = GameObject.Find("RightAudioSource").GetComponent<AudioSource>();
        if (audioSource[1] == null )
        { Debug.Log("Right Side Audio not found"); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hit") && !_gm.hasScore)
        {
            _gm._currentAttemptNo++;

            _gm.hasScore = true;
            StartCoroutine(TakeAnotherShotRoutine());

            _gm.ScoringSystem(gameObject.tag);

            if (_pierchedArrowPrefab != null)
            { Instantiate(_pierchedArrowPrefab, other.gameObject.transform.position, Quaternion.identity); }
            else { Debug.LogWarning("Prefab is Not Assigned"); }

            GameObject arrow = GameObject.Find("ShootArrow" +
                "");
            if (arrow != null)
            { Destroy(arrow); }
            else { Debug.LogWarning("Arrow not found"); }

            audioSource[0].Play();
            audioSource[1].Play();
        }
    }

    IEnumerator TakeAnotherShotRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        _gm.hasScore = false;
    }
}
