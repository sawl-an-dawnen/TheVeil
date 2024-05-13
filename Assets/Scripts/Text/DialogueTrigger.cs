using UnityEngine;
using TMPro;
using System.Threading;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textUI;
    public string[] lines;
    public float duration;
    public string prompt;
    public bool destroyOnUse = true;
    private int i = 0;
    private bool active = false;
    private float timer = 0;
    private float lineTime;
    private GameManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        lineTime = duration / lines.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (i < lines.Length)
            {
                textUI.text = lines[i];
                timer += Time.deltaTime;
                if (timer > lineTime)
                {
                    i++;
                    timer = 0f;
                }
            }
            else 
            {
                i = 0;
                timer = 0;
                active = false;
                if (destroyOnUse) 
                {
                    Destroy(gameObject);
                }
            }
        }
        else 
        {
            textUI.text = "";
            dialogueCanvas.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        manager.Focus(true, false, false);
        
        if (other.gameObject.CompareTag("Player")) 
        {
            dialogueCanvas.SetActive(true);
            i = 0;
            timer = 0;
            active = true;
        }

    }

    public void Interact()
    {
        manager.Focus(true, false, false);
        dialogueCanvas.SetActive(true);
        i = 0;
        timer = 0;
        active = true;
    }

    public string Prompt
    {
        get
        {
            return prompt;
        }
    }

    public void Reset() 
    {
        active = false;
        timer = 0f;
        textUI.text = "";
        dialogueCanvas.SetActive(false);
    }
}
