using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    public string[] lines;
    public GameObject lookAtObject;
    public bool destroyOnInteract = false;
    private DialogueController dialogueController;

    void Awake()
    {
        dialogueController = GameObject.FindGameObjectWithTag("Dialogue_Controller").GetComponent<DialogueController>();
    }

    public void Interact()
    {
        dialogueController.Speak(lines, lookAtObject);
        if (destroyOnInteract) 
        {
            Destroy(this);
        }
    }

    public string Prompt
    {
        get
        {
            return "[talk]";
        }
    }
}
