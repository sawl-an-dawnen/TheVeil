using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    private GameObject crosshairCanvas;
    private GameObject promptCanvas;
    private GameObject player;
    private FirstPersonController control;
    private Interactor interactor;
    private Footsteps footsteps;
    private Rigidbody rb;
    private VideoPlayer[] videos;
    private DialogueTrigger[] dialogues;
    private AudioSource[] audioSources;

    // Start is called before the first frame update
    void Awake()
    {
        crosshairCanvas = GameObject.FindGameObjectWithTag("Crosshair");
        promptCanvas = GameObject.FindGameObjectWithTag("Cursor_Prompt");
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<FirstPersonController>();
        interactor = player.GetComponent<Interactor>();
        footsteps = player.GetComponent<Footsteps>();
        rb = player.GetComponent<Rigidbody>();
    }

    public void FreezeControl() {
        rb.velocity = Vector3.zero;
        control.enabled = false;
        interactor.enabled = false;
        footsteps.enabled = false;
        promptCanvas.SetActive(false);
        crosshairCanvas.SetActive(false);
    }

    public void ReleaseControl() 
    {
        promptCanvas.SetActive(true);
        crosshairCanvas.SetActive(true);
        control.enabled = true;
        interactor.enabled = true;
        footsteps.enabled = true;
    }

    public void Focus(bool dia, bool vid, bool aud)
    {
        if (dia) { 
            dialogues = FindObjectsOfType<DialogueTrigger>();
            foreach (DialogueTrigger d in dialogues)
            {
                d.Reset();
            }
        }
        if (vid)
        {
            videos = FindObjectsOfType<VideoPlayer>();
            foreach (VideoPlayer v in videos)
            {
                v.Pause();
            }
        }
        if (aud)
        {
            audioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audioSources)
            {
                if (a.gameObject.CompareTag("SFX-1") || a.gameObject.CompareTag("SFX-2"))
                {
                    continue;
                }
                //Debug.Log(a);
                a.Pause();
            }
        }

    }

    public void ReleaseFocus()
    {
        videos = FindObjectsOfType<VideoPlayer>();
        foreach (VideoPlayer v in videos)
        {
            v.Play();
        }
        audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audioSources)
        {
            if (a.enabled == true) 
            {
                a.Play();
            }

        }
    }
}
