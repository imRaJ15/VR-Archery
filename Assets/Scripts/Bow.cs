using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bow : MonoBehaviour
{
    [SerializeField] XRSocketInteractor _arrowSocket;
    [SerializeField] Vector3 _offset;
    [SerializeField] AudioSource _audioSource;

    public bool isArrowAttached;

    private void Awake()
    {
        isArrowAttached = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        _arrowSocket.selectEntered.AddListener(OnArrowAttached);
        _arrowSocket.selectExited.AddListener(OnArrowDisAttached);
    }

    void OnArrowAttached(SelectEnterEventArgs args)
    {
        isArrowAttached = true;
        GameObject arrow = args.interactableObject.transform.gameObject;
        arrow.tag = "Arrow";
        arrow.gameObject.name = "ShootArrow";
    }

    void OnArrowDisAttached(SelectExitEventArgs args)
    { isArrowAttached = false; }

    public void ShootArrow()
    {
        XRGrabInteractable xRGrabInteractable = GameObject.FindGameObjectWithTag("Arrow").GetComponent<XRGrabInteractable>();
        xRGrabInteractable.enabled = false;

        Arrow arrow = GameObject.FindGameObjectWithTag("Arrow").GetComponent<Arrow>();
        arrow.enabled = true;

        GameObject arrowGM = GameObject.FindGameObjectWithTag("Arrow");
        arrowGM.tag = "Untagged";

        _audioSource.Play();
    }
}
