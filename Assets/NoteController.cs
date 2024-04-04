using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    public GameObject noteCanvas;
    public RawImage visualUI;
    public TextMeshProUGUI textUI;

    public Button leftButton;
    public Button rightButton;
    public Button closeButton;
 
    private string[] pages;

    private int i = 0;
    private bool active = false;

    private FirstPersonController control;
    private Interactor interactor;

    private void Start()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        interactor = GameObject.FindGameObjectWithTag("Player").GetComponent<Interactor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            textUI.text = pages[i];
            if (i == 0)
            {
                leftButton.interactable = false;
            }
            else
            {
                leftButton.interactable = true;
            }
            if (i == pages.Length - 1)
            {
                rightButton.interactable = false;
            }
            else
            {
                rightButton.interactable = true;
            }
        }
    }

    public void ReadNote(string[] pages, Texture2D visual) 
    {
        control.enabled = false;
        interactor.enabled = false;
        noteCanvas.SetActive(true);
        this.pages = pages;
        visualUI.texture = visual;
        active = true;
        Time.timeScale = 0;
        Camera.main.GetComponent<AudioListener>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PageLeft() {
        if (i > 0) {
            i--;        
        }
    }
    public void PageRight() {
        if (i < pages.Length - 1) {
            i++;
        }
    }
    public void CloseNote() {

        active = false;
        pages = null;
        visualUI.texture = null;
        i = 0;
        noteCanvas.SetActive(false);
        control.enabled = true;
        interactor.enabled = true;
        Time.timeScale = 1;
        Camera.main.GetComponent<AudioListener>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
