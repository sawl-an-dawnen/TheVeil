using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public string[] pages;
    public Texture2D visual;
    private NoteController noteController;

    void Awake()
    {
        noteController = GameObject.FindGameObjectWithTag("Note_Controller").GetComponent<NoteController>();
    }

    public void Interact() 
    {
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
