using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public string[] pages;
    public Texture2D visual;
    public AudioClip soundEffect;
    private NoteController noteController;
    private AudioSource audioSource;

    void Awake()
    {
        noteController = GameObject.FindGameObjectWithTag("Note_Controller").GetComponent<NoteController>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-1").GetComponent<AudioSource>();
    }

    public void Interact() 
    {
        audioSource.Stop();
        audioSource.PlayOneShot(soundEffect);
        noteController.ReadNote(pages, visual);
    }

    public string Prompt
    {
        get
        {
            return "[read]";
        }
    }
}
