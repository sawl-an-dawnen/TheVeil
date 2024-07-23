using UnityEngine;

using UnityEngine;
using System.Collections;

public class Lighter : MonoBehaviour, IInteractable
{
    public bool inPossessionOf = false;
    public float heightChange = 0.5f;
    public GameObject flame;
    public AudioClip onClip, offClip;
    public Lighter referenceLighter;

    public bool triggerEvent = false;
    public AudioClip eventSoundEffect;
    public PhysicalDoor door;
    public GameObject[] activate;
    public GameObject[] destroy;



    private bool status = false;
    private AudioSource audioSource;
    private AudioSource audioSource_2;
    private AudioSource ambientSound;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        audioSource_2 = GameObject.FindGameObjectWithTag("SFX-1").GetComponent<AudioSource>();
        ambientSound = gameObject.GetComponent<AudioSource>();
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
        ambientSound.enabled = true;
    }
    public void TurnOff() {
        ambientSound.enabled = false;
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
    public void TriggerEvent() 
    {
        door.CloseDoor(true);
        audioSource_2.PlayOneShot(eventSoundEffect);
        foreach (GameObject a in activate)
        {
            a.SetActive(true);
        }
        foreach (GameObject d in destroy)
        {
            Destroy(d);
        }
    }

    public void Interact() {
        AquireLighter();
        if (triggerEvent) TriggerEvent();
    }

    public string Prompt
    {
        get
        {
            return "[pick up]";
        }
    }
}
