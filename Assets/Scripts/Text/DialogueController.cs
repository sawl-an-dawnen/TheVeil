using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textUI;
    public Button rightButton;
    public Button closeButton;
    public AudioClip rightSound, closeSound;
    private GameManager manager;
    private string[] lines;
    private int i = 0;
    private bool active = false;
    private bool activeThought = false;
    private float timer = 0;
    private float lineTime;
    private Camera playerCamera;
    private AudioSource audioSource;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerCamera = Camera.main;
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            textUI.text = lines[i];
            if (i == lines.Length - 1)
            {
                rightButton.gameObject.SetActive(false);
                closeButton.gameObject.SetActive(true);
            }
        }
    }

    public void Speak(string[] lines, GameObject lookAt)
    {
        manager.FreezeControl();
        manager.Focus(true, false, false);
        playerCamera.transform.LookAt(lookAt.transform);
        dialogueCanvas.SetActive(true);
        this.lines = lines;
        active = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Continue()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(rightSound);
        if (i < lines.Length - 1)
        {
            i++;
        }
    }

    public void CloseDialogue()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(closeSound);
        textUI.text = "";
        active = false;
        lines = null;
        i = 0;
        rightButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);
        dialogueCanvas.SetActive(false);
        manager.ReleaseControl();
        Cursor.lockState = CursorLockMode.Locked;
    }

}
