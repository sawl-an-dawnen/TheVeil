using UnityEngine;
using System.Collections;

public class Lighter : MonoBehaviour, IInteractable
{
    public bool inPossessionOf = false;
    public float heightChange = 0.5f;
    public GameObject flame;
    public AudioClip onClip, offClip;
    public Lighter referenceLighter;
    private bool status = false;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (inPossessionOf && Input.GetKeyDown(KeyCode.F) && status)
        {
            TurnOff();
        }
        else if (inPossessionOf && Input.GetKeyDown(KeyCode.F) && !status)
        {
            TurnOn();
        }
    }

    public void TurnOn() {
        audioSource.Stop();
        audioSource.PlayOneShot(onClip);
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + heightChange, gameObject.transform.localPosition.z);
        flame.SetActive(true);
        status = true;
    }
    public void TurnOff() {
        audioSource.Stop();
        audioSource.PlayOneShot(offClip);
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - heightChange, gameObject.transform.localPosition.z);
        flame.SetActive(false);
        status = false;
    }

    public void AquireLighter() {
        referenceLighter.inPossessionOf = true;
        referenceLighter.TurnOn();
        Destroy(gameObject);
    }
    public void LoseLighter() {
        referenceLighter.inPossessionOf = false;
        referenceLighter.TurnOff();
    }

    public void Interact() {
        AquireLighter();
    }

    public string Prompt
    {
        get
        {
            return "[pick up]";
        }
    }
}
