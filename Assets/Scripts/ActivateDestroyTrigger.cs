using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDestroyTrigger : MonoBehaviour
{
    public GameObject[] activate;
    public GameObject[] destroy;
    public AudioClip sound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (sound != null) 
        {
            audioSource.Stop();
            audioSource.PlayOneShot(sound);
        }
        foreach (GameObject a in activate)
        {
            a.SetActive(true);
        }
        foreach (GameObject d in destroy)
        {
            Destroy(d);
        }
    }
}
