using UnityEngine;


public class LightSwitch : MonoBehaviour, IInteractable
{
    public PhysicalLight[] lights;
    public AudioClip sound;
    private string text;
    private AudioSource audioSource;
    private PhysicalLight proxy;

    void Awake() {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        proxy = lights[0];
    }

    void Update()
    {
        //if on
        if (proxy.power && proxy.status) {
            text = "[turn off]";
        }
        //if off
        if (proxy.power && !proxy.status) {
            text = "[turn on]";
        }
        //no power
        if (!proxy.power)
        {
            text = "[no power]";
        }
    }

    public void Interact() {
        audioSource.Stop();
        audioSource.PlayOneShot(sound);
        foreach (PhysicalLight l in lights)
        {
            l.status = !l.status;
        }
    }

    public string Prompt {
        get 
        {
            return this.text;
        }
    }
}
