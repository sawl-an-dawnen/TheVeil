using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public UnityEngine.UI.Toggle toggle;
    public UnityEngine.UI.Slider slider;
    //public AudioClip selectionSound;

    private GameManager manager;
    //private AudioSource audioSource;
    // Start is called before the first frame update

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    void Start()
    {
        toggle.isOn = manager.invertedCamera;
        slider.value = manager.sensitivity*.1f;

        slider.onValueChanged.AddListener(delegate { manager.updateSensitivity(slider); });
        toggle.onValueChanged.AddListener(delegate { manager.updateInversion(toggle); });
    }
}
