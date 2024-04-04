using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public string[] pages;
    public Texture2D visual;

    private NoteController noteController;

    // Start is called before the first frame update
    void Start()
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
