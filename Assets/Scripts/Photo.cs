using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour, IInteractable
{
    public int id;
    public AudioClip audioClip;
    public RawImage image;

    private GameManager gameManager;
    private AudioSource audioSource;


    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    public void Interact()
    {
        audioSource.PlayOneShot(audioClip);
        image.color = new Color(255, 255, 255, 255);
        gameManager.photos[id] = true;
        Destroy(gameObject);
    }
    public string Prompt
    {
        get
        {
            return "[pick up]";
        }
    }
}
