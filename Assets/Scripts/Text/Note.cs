using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public string[] pages;
    public string prompt = "[read]";
    public Texture2D visual;
    public AudioClip soundEffect;
    public bool destroyOnInteract = false;
    public GameObject[] activate;
    public GameObject[] destroy;

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

        foreach (GameObject a in activate)
        {
            a.SetActive(true);
        }
        foreach (GameObject d in destroy)
        {
            Destroy(d);
        }
        if (destroyOnInteract)
        {
            Destroy(gameObject);
        }
    }

    public string Prompt
    {
        get
        {
            return prompt;
        }
    }
}
