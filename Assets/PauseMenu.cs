using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool active = false;
    private GameManager manager;
    //private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
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
        pauseCanvas.SetActive(true);
        manager.FreezeControl();
        active = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Unpause()
    {
        pauseCanvas.SetActive(false);
        manager.ReleaseControl();
        active = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
