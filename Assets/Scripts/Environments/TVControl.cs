using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class TVControl : MonoBehaviour, IInteractable
{
    public GameObject video;
    public RenderTexture offTexture;
    public GameObject backlight;
    public AudioClip remoteSound;
    public bool status = false;
    private AudioSource audioSource;
    //private AudioSource tvAudio;
    private string text;
    private VideoPlayer videoPlayer;
    private Texture temp;
    private Material mat;


    void Awake() 
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        videoPlayer = video.GetComponent<VideoPlayer>();
        mat = video.GetComponent<Renderer>().material;
        temp = mat.mainTexture;
    }

    void Start() 
    {
        if (status)
        {
            //tvAudio.Play();
            videoPlayer.Play();
            mat.mainTexture = temp;
            mat.SetColor("_EmissionColor", Color.white);
            backlight.SetActive(true);
        }
        else
        {
            //tvAudio.Pause();
            videoPlayer.Pause();
            mat.mainTexture = offTexture;
            mat.SetColor("_EmissionColor", Color.black);
            backlight.SetActive(false);
        }
    }

    void Update() 
    {
        if (status) {
            text = "[turn off]";
        }
        else 
        {
            text = "[turn on]";
        }
    }

    public void Interact()
    {
        if (status) 
        {
            //tvAudio.Pause();
            videoPlayer.Pause();
            mat.mainTexture = offTexture;
            mat.SetColor("_EmissionColor", Color.black);
            backlight.SetActive(false);
        }
        else
        {
            //tvAudio.Play();
            videoPlayer.Play();
            mat.mainTexture = temp;
            mat.SetColor("_EmissionColor", Color.white);
            backlight.SetActive(true);
        }
        //audioSource.Stop();
        //video.SetActive(!video.activeSelf);
        //backLight.SetActive(!backLight.activeSelf);
        status = !status;
        audioSource.PlayOneShot(remoteSound);
    }
    public string Prompt
    {
        get
        {
            return this.text;
        }
    }
}
