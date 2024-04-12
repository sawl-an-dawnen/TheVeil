using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public GameObject promptCanvas;
    public GameObject crosshairCanvas;


    public TextMeshProUGUI textUI;
    public Button rightButton;
    public Button closeButton;

    private string[] lines;

    private int i = 0;
    private bool active = false;

    private FirstPersonController control;
    private Interactor interactor;

    private Rigidbody rb;
    private Camera playerCamera;

    private void Start()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        interactor = GameObject.FindGameObjectWithTag("Player").GetComponent<Interactor>();
        rb = control.gameObject.GetComponent<Rigidbody>();
        playerCamera = Camera.main;
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
        playerCamera.transform.LookAt(lookAt.transform);
        rb.velocity = Vector3.zero;
        control.enabled = false;
        interactor.enabled = false;
        promptCanvas.SetActive(false);
        crosshairCanvas.SetActive(false);
        dialogueCanvas.SetActive(true);
        this.lines = lines;
        active = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Continue()
    {
        if (i < lines.Length - 1)
        {
            i++;
        }
    }
    public void CloseDialogue()
    {
        textUI.text = "";
        active = false;
        lines = null;
        i = 0;
        rightButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);
        dialogueCanvas.SetActive(false);
        promptCanvas.SetActive(true);
        crosshairCanvas.SetActive(true);
        control.enabled = true;
        interactor.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
