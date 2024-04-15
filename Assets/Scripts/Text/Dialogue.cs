using UnityEngine;

public class Dialogue : MonoBehaviour, IInteractable
{
    public string[] lines;
    public GameObject lookAtObject;

    private DialogueController dialogueController;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = GameObject.FindGameObjectWithTag("Dialogue_Controller").GetComponent<DialogueController>();
    }

    public void Interact()
    {
        dialogueController.Speak(lines, lookAtObject);
    }

    public string Prompt
    {
        get
        {
            return "[talk]";
        }
    }
}