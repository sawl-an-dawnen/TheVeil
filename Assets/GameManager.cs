using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject crosshairCanvas;
    private GameObject promptCanvas;
    private GameObject player;
    private FirstPersonController control;
    private Interactor interactor;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        crosshairCanvas = GameObject.FindGameObjectWithTag("Crosshair");
        promptCanvas = GameObject.FindGameObjectWithTag("Cursor_Prompt");
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<FirstPersonController>();
        interactor = player.GetComponent<Interactor>();
        rb = player.GetComponent<Rigidbody>();
    }

    public void FreezeControl() {
        rb.velocity = Vector3.zero;
        control.enabled = false;
        interactor.enabled = false;
        promptCanvas.SetActive(false);
        crosshairCanvas.SetActive(false);
    }

    public void ReleaseControl() 
    {
        promptCanvas.SetActive(true);
        crosshairCanvas.SetActive(true);
        control.enabled = true;
        interactor.enabled = true;
    }
}
