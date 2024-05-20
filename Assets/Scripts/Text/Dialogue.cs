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
        dialogueController.Speak(lines, lookAtObject);
        if (destroyOnInteract) 
        {
            Destroy(this);
        }
        foreach (GameObject a in activate)
        {
            a.SetActive(true);
        }
        foreach (GameObject d in destroy)
        {
            Destroy(d);
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
