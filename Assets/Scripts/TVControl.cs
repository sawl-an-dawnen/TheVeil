using UnityEngine;
using UnityEngine.Video;

public class TVControl : MonoBehaviour, IInteractable
{
    public GameObject video;
    public GameObject backLight;
    public AudioClip remoteSound;

    private AudioSource audioSource;
    private string text;

    void Start() 
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    void Update() 
    {
        if (video.activeSelf == true) {
            text = "[turn off]";
        }
        else 
        {
            text = "[turn on]";
        }
    }

    public void Interact()
    {
        audioSource.Stop();
        video.SetActive(!video.activeSelf);
        backLight.SetActive(!backLight.activeSelf);
        audioSource.PlayOneShot(remoteSound);
    }
    public string Prompt
    {
        get
        {
            return this.text;
        }
    }
}
