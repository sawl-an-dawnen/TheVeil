using UnityEngine;
using TMPro;
using System.Threading;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TextMeshProUGUI textUI;
    public string[] lines;
    public float duration;
    public bool destroyOnUse = true;
    private int i = 0;
    private bool active = false;
    private float timer = 0;
    private float lineTime;

    private void Awake()
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
        if (other.gameObject.CompareTag("Player")) 
        {
            dialogueCanvas.SetActive(true);
            i = 0;
            timer = 0;
            active = true;
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
