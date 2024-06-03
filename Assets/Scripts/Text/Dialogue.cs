using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    public string[] lines;
    public string prompt = "[talk]";
    public GameObject lookAtObject;
    public bool destroyOnInteract = false;

    public GameObject[] activate;
    public GameObject[] destroy;

    private DialogueController dialogueController;

    void Awake()
    {
        dialogueController = GameObject.FindGameObjectWithTag("Dialogue_Controller").GetComponent<DialogueController>();
    }

    public void Interact()
    {
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
