using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        { Debug.Log("Hello"); } //Destroy(_gameObject); }
    }
}
