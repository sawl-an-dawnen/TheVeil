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
    public AudioClip leftSound, rightSound, closeSound;
    private string[] pages;
    private int i = 0;
    private bool active = false;
    private FirstPersonController control;
    private Interactor interactor;
    private AudioSource audioSource;

    private void Awake()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        interactor = GameObject.FindGameObjectWithTag("Player").GetComponent<Interactor>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
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
        Cursor.lockState = CursorLockMode.None;
    }

    public void PageLeft() {
        audioSource.Stop();
        audioSource.PlayOneShot(leftSound);
        if (i > 0) {
            i--;        
        }
    }
    public void PageRight() {
        audioSource.Stop();
        audioSource.PlayOneShot(rightSound);
        if (i < pages.Length - 1) {
            i++;
        }
    }
    public void CloseNote() {
        audioSource.Stop();
        audioSource.PlayOneShot(closeSound);
        active = false;
        pages = null;
        visualUI.texture = null;
        i = 0;
        noteCanvas.SetActive(false);
        control.enabled = true;
        interactor.enabled = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
