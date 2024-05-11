using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioClip pauseSound, selectionSound;
    private bool active = false;
    private GameManager manager;
    private VideoPlayer[] videos;
    private AudioSource audioSource;

    //private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && active)
        {
            Unpause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !active)
        {
            Pause();
        }

    }
    public void Pause()
    {
        audioSource.PlayOneShot(pauseSound);
        pauseCanvas.SetActive(true);
        manager.FreezeControl();
        manager.Focus(false, true, true);
        active = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Unpause()
    {
        audioSource.PlayOneShot(selectionSound);
        pauseCanvas.SetActive(false);
        manager.ReleaseControl();
        manager.ReleaseFocus();
        active = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
