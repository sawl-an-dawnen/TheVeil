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
        if (lights.Length != 0)
        {
            proxy = lights[0];
        }
        else 
        {
            proxy = null;
        }
    }

    void Update()
    {
        //no power
        if (proxy == null || !proxy.power)
        {
            text = "[no power]";
            return;
        }
        //if on
        if (proxy.power && proxy.status) {
            text = "[turn off]";
        }
        //if off
        if (proxy.power && !proxy.status) {
            text = "[turn on]";
        }

    }

    public void Interact() {
        audioSource.Stop();
        audioSource.PlayOneShot(sound);
        if (lights.Length != 0)
        {
            foreach (PhysicalLight l in lights)
            {
                l.status = !l.status;
            }
        }
    }

    public string Prompt {
        get 
        {
            return this.text;
        }
    }
}
