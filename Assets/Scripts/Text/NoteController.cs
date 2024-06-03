using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NoteController : MonoBehaviour
{
    public GameObject noteCanvas;
    public RawImage visualUI;
    public TextMeshProUGUI textUI;
    public Button leftButton;
    public Button rightButton;
    public Button closeButton;
    public AudioClip leftSound, rightSound, closeSound;
    [HideInInspector]
    public bool active = false;
    private string[] pages;
    private int i = 0;
    private GameManager manager;
    private AudioSource audioSource;
    private GameObject[] activate, destroy;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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

    public void ReadNote(string[] pages, Texture2D visual, GameObject[] activate, GameObject[] destroy)
    {
        manager.FreezeControl();
        manager.Focus(true,true,true);
        noteCanvas.SetActive(true);
        this.pages = pages;
        visualUI.texture = visual;
        this.activate = activate;
        this.destroy = destroy;
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
        foreach (GameObject a in activate)
        {
            a.SetActive(true);
        }
        foreach (GameObject d in destroy)
        {
            Destroy(d);
        }
        activate = null;
        destroy = null;
        noteCanvas.SetActive(false);
        manager.ReleaseControl();
        manager.ReleaseFocus();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
