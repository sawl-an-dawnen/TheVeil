using UnityEditor;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public AudioClip sound;
    public bool power = true;
    public bool status = false;
    private string text;
    private AudioSource audioSource;
    private Light lightComponent;

    void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        lightComponent = lightComponent = GetComponentInChildren<Light>();
    }


    void Update()
    {
        //if on
        if (power && status)
        {
            text = "[turn off]";
            lightComponent.enabled = true;
        }
        //if off
        if (power && !status)
        {
            text = "[turn on]";
            lightComponent.enabled = false;
        }
        //no power
        if (!power)
        {
            text = "[no power]";
            lightComponent.enabled = false;
        }
    }

    public void Interact()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sound);
        status = !status;
        //lightComponent.enabled = !lightComponent.enabled;
    }

    public string Prompt
    {
        get
        {
            return text;
        }
    }
}
