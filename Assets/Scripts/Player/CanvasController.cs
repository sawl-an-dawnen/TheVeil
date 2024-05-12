using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject activate;
    public GameObject deactivate;
    public AudioClip sound;
    private AudioSource audioSource;
    //public GameObject firstSelected;
    //public EventSystem eventSystem;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }
    public void Trigger() {
        audioSource.Stop();
        audioSource.PlayOneShot(sound);
        activate.SetActive(true);
        deactivate.SetActive(false);
        //eventSystem.SetSelectedGameObject(firstSelected);
    }
}
