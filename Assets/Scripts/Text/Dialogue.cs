using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    public string[] lines;
    public string prompt = "[talk]";
    public GameObject lookAtObject;
    public AudioClip audioClip;
    public bool destroyOnInteract = false;

    public GameObject[] activate;
    public GameObject[] destroy;


    private DialogueController dialogueController;
    private AudioSource audioSource;


    void Awake()
    {
        dialogueController = GameObject.FindGameObjectWithTag("Dialogue_Controller").GetComponent<DialogueController>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-1").GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (audioClip != null) 
        {
            audioSource.PlayOneShot(audioClip);
        }
        dialogueController.Speak(lines, lookAtObject, activate, destroy);

        if (destroyOnInteract)
        {
            Destroy(this);
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
