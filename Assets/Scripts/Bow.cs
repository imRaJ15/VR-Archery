using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bow : MonoBehaviour
{
    [SerializeField] XRSocketInteractor _arrowSocket;
    [SerializeField] Vector3 _offset;
    [SerializeField] AudioSource _audioSource;

    public bool IsArrowAttached { get; private set; }

    private void Awake()
    {
        IsArrowAttached = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        _arrowSocket.selectEntered.AddListener(OnArrowAttached);
        _arrowSocket.selectExited.AddListener(OnArrowDisAttached);
    }

    void OnArrowAttached(SelectEnterEventArgs args)
    {
        IsArrowAttached = true;
        GameObject arrow = args.interactableObject.transform.gameObject;
        arrow.tag = "Arrow";
        arrow.gameObject.name = "ShootArrow";
    }

    void OnArrowDisAttached(SelectExitEventArgs args)
    { IsArrowAttached = false; }

    public void ShootArrow()
    {
        if (IsArrowAttached)
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
}
