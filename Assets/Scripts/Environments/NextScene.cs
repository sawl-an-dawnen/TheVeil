using UnityEngine;

public class NextScene : MonoBehaviour, IInteractable
{
    public AudioClip soundEffect;
    public string prompt;
    //public bool progressToNextScene;

    private FadeController fader;
    private bool activated = false;
    private AudioSource audioSource;
    private GameManager manager;
    // Start is called before the first frame update
    void Awake()
    {
        fader = GameObject.FindGameObjectWithTag("Fade_Controller").GetComponent<FadeController>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-1").GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && fader.fading)
        {
            Debug.Log("ACTIVE FADING");
        }
        else if (activated)
        {
            gameObject.GetComponent<SceneLoader>().LoadScene();
        }
    }

    public void Interact()
    {
        manager.FreezeControl();
        audioSource.PlayOneShot(soundEffect);
        fader.FadeOut();
        activated = true;
    }

    public string Prompt
    {
        get
        {
            return prompt;
        }
    }
}
