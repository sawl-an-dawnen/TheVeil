using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    private FadeController fader;
    private bool activated = false;
    // Start is called before the first frame update
    void Awake()
    {
        fader = GameObject.FindGameObjectWithTag("Fade_Controller").GetComponent<FadeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && fader.fading)
        {
            Debug.Log("ACTIVE FADING");
        }
        else if (activated) {
            Debug.Log("SLEEPING");
        }
    }

    public void Interact()
    {
        fader.FadeOut();
        activated = true;
    }

    public string Prompt
    {
        get
        {
            return "[sleep]";
        }
    }
}
